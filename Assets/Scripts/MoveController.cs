using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
  [SerializeField] private float horizontalMoveFactor;
  [SerializeField] private float jumpForce;
  [SerializeField] private float p2Factor = 1;  
  private PhotonView photonView;
  private Rigidbody2D rb;  
  void OnAwake()
  {
    
  }
  void Start()
    {
    photonView = GetComponent<PhotonView>();
    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    MovePlayer();

    }
  void MovePlayer()
  {
    if (photonView.IsMine && PhotonNetwork.IsConnected == true)
    {   
      P1HorizMove();
      P1ButtonActions();
      //Debug.Log("Not Elsing the input!");
    }
    //else
    //{
    //  Debug.Log("Elseing the input!");
    //  P2HorizMove();
    //  P2ButtonActions();
    //}
  }
  void P1HorizMove()
  {    
    var horizAxisPlayerOne = Input.GetAxis("Horizontal");
    var vertAxisPlayerOne = Input.GetAxis("Vertical");

   if (horizAxisPlayerOne > 0) { Debug.Log("Top Pos"); this.transform.position += new Vector3(horizontalMoveFactor * horizAxisPlayerOne, 0, 0); }
    if (horizAxisPlayerOne < 0) { Debug.Log("Bottom Pos"); this.transform.position -= new Vector3(horizontalMoveFactor * horizAxisPlayerOne * -1, 0, 0); }
    
    Debug.Log($"{horizAxisPlayerOne}  {vertAxisPlayerOne}   {this.transform.position}");    
  }
  void P2HorizMove()
  {
    if (Input.GetKeyDown(KeyCode.Keypad6))
    {

      this.transform.position += new Vector3(p2Factor * 1, 0, 0);
      Debug.Log("P2 H Move KeyPd6");
    }
    if (Input.GetKeyDown(KeyCode.Keypad4))
    {
      this.transform.position += new Vector3(p2Factor * -1, 0, 0);
      Debug.Log("P2 H Move KeyPd4");
    }    
  }
  void P1ButtonActions()
  {
    bool jumpButton = Input.GetKeyDown(KeyCode.LeftControl);
    if (jumpButton) 
    { 
      rb.AddForce(new Vector2(0, jumpForce));
      Debug.Log("P1 Jump LeftCtrl");
    }
    Debug.Log($"{jumpButton} {rb.velocity}");
    
  }
  void P2ButtonActions()
  {
    bool jumpButton = Input.GetKeyDown(KeyCode.KeypadPlus);
    if (jumpButton) { rb.AddForce(new Vector2(0, Mathf.Abs(jumpForce))); }
    Debug.Log($"{jumpButton} {rb.velocity}");
    Debug.Log("P2 Jump KeyPd + For Obj: " + this.name);
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.collider.tag == "Environment")
    {
      this.photonView.RPC("InAirMsg", RpcTarget.All);
      InAirMsg();
    }
  }
  [PunRPC]
  private void InAirMsg()
  {
    Debug.Log($"{this.name} is in Air");
  }
}
