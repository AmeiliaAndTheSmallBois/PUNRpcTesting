using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameSetupController : MonoBehaviour
{
  [SerializeField] private string player1PrefabName;
  [SerializeField] private string player1PrefabFolderName;
  [SerializeField] private string player2PrefabName;
  [SerializeField] private string player2PrefabFolderName;
  [SerializeField] private GameObject associatedButton;
  [SerializeField] private Text status;


  // Start is called before the first frame update
  // Update is called once per frame
  private void Start()
  {
    //CreatePlayer();
  }
  public void CreatePlayer()
  {
    Debug.Log("Creating Player");
    if(PhotonNetwork.IsMasterClient)
    {
      Debug.Log("I am the current Player 1");
      PhotonNetwork.Instantiate(Path.Combine(player1PrefabFolderName, player1PrefabName), Vector3.zero, Quaternion.identity);
      status.text += "Set as Player 1\n";
    }
    else
    {
      Debug.Log("I am the current Player 2");
      PhotonNetwork.Instantiate(Path.Combine(player2PrefabFolderName, player2PrefabName), Vector3.zero, Quaternion.identity);
      status.text += "Set as Player 2\n";
    }
    associatedButton.SetActive(false);
    
  }
}
