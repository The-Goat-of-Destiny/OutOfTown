using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManagerUI : NetworkBehaviour
{
    [SerializeField] private string GameScene;
    [SerializeField] private TestRelay Relay;
    [SerializeField] private TMP_Text RoomCode;
    [SerializeField] private TMP_InputField CodeInput;


    public void StartHost()
    {
        Relay.CreateRelay();
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
        RoomCode.gameObject.SetActive(true);
    }

    public void StartClient()
    {
        Relay.JoinRelay(CodeInput.text);
    }

    public void StartGame()
    {
        StartGameServerRpc();
    }

    [ServerRpc]
    void StartGameServerRpc()
    {
        //if (IsOwner) return;

        //Debug.Log("Starting Game");
        LoadScene();// SceneManager.LoadScene("SampleScene");
    }

    public static void LoadScene()
    {
        Debug.Log("Loading Scene");
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RoomCode.text = TestRelay.joinCode;
    }
}
