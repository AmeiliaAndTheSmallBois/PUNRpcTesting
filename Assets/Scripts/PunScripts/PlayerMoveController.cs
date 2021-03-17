using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMoveController : MonoBehaviour
{
  [SerializeField] float moveFactor;
  private PhotonView photonView;

  private void Start()
  {
    photonView = gameObject.GetComponent<PhotonView>();

    if(photonView == null)
    {
      Debug.Log("PhotonView in Move Controller is null");
    }
  }

  // Update is called once per frame
  void Update()
  {
    if(photonView.IsMine == true && PhotonNetwork.IsConnected == true)
    {
      if (Input.GetKey(KeyCode.W))
      {
        transform.position += new Vector3(0, moveFactor * 1, 0);
      }
      if (Input.GetKey(KeyCode.A))
      {
        transform.position += new Vector3(moveFactor * -1, 0, 0);
      }
      if (Input.GetKey(KeyCode.S))
      {
        transform.position += new Vector3(0, moveFactor * -1, 0);
      }
      if (Input.GetKey(KeyCode.D))
      {
        transform.position += new Vector3(moveFactor * 1, 0 ,0);
      }
    }
  }
}