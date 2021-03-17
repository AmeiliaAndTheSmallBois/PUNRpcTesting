using UnityEngine;
using Photon;
using Photon.Pun;
using UnityEngine.UI;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
  // Start is called before the first frame update
  [SerializeField] private int multiplayerSceneIndex;
  [SerializeField] private GameSetupController gameController;
  [SerializeField] private Text statusUpdate;
  [SerializeField] GameObject gameObjButton;
    
  public override void OnEnable()
  {
    PhotonNetwork.AddCallbackTarget(this);
  }
  public override void OnDisable()
  {
    PhotonNetwork.RemoveCallbackTarget(this);
  }
  public override void OnJoinedRoom()
  {   Debug.Log("Joined Room");
    statusUpdate.text += $"Joined Room: {PhotonNetwork.CurrentRoom.Name}";

      StartGame();    
  }
  private void StartGame()
    {
      if (PhotonNetwork.IsMasterClient)
      {
        Debug.Log("Starting the Game, I am the Master!");
      //PhotonNetwork.LoadLevel(multiplayerSceneIndex);
      }
    //Instantiate(gameController);
    gameObjButton.SetActive(true);
    }

}
