
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  

    void Start()
    {
    PhotonNetwork.ConnectUsingSettings();      
    PhotonNetwork.ConnectToRegion("usw");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public override void OnConnectedToMaster()
  {
    Debug.Log($"We are connected to the {PhotonNetwork.CloudRegion} server!");
   
  }
  
  
}
