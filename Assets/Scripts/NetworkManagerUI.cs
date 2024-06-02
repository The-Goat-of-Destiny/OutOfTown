using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class NetworkManagerUI : NetworkBehaviour
{
    public static NetworkManagerUI Singleton;
    [SerializeField] private string GameScene;
    [SerializeField] private TestRelay Relay;
    [SerializeField] private TMP_Text RoomCode;
    [SerializeField] private TMP_InputField CodeInput;

    [SerializeField] private Transform ConnectedPlayerList;

    private IReadOnlyDictionary<ulong, NetworkClient> lastConnectedClients;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        PlayerConnectedServerRpc();
    }

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
        LoadScene();
    }

    // May be redundant, try moving to StartGameServerRpc
    public static void LoadScene()
    {
        Debug.Log("Loading Scene");
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    [ServerRpc(RequireOwnership = false)]
    public void PlayerConnectedServerRpc()
    {
        if (!IsSpawned || !IsHost) return;
        print("Server recieved Player Connected event");
        for (int i = 0; i < 4; i++)
        {
            if (NetworkManager.Singleton.ConnectedClientsList.Count > i) PlayerConnectedClientRpc(NetworkManager.Singleton.ConnectedClientsList[i].ClientId.ToString(), i);
            else PlayerConnectedClientRpc("", i);
        }
    }

    [ClientRpc]
    private void PlayerConnectedClientRpc(string clientUsername, int i)
    {
        print("Player Connected");
        OnPlayerJoin(clientUsername, i);
    }

    private async void OnPlayerJoin(string clientUsername, int i)
    {
        while (ConnectedPlayerList == null)
        {
            await Task.Yield();
        }
        print(ConnectedPlayerList);
        print(i);
        print(ConnectedPlayerList.GetChild(i));
        print(ConnectedPlayerList.GetChild(i).GetComponent<PlayerCard>());
        ConnectedPlayerList.GetChild(i).GetComponent<PlayerCard>().UpdateVisuals("Player #" + clientUsername);
    }

    void Awake()
    {
        Singleton = this;
        //NetworkManager.Singleton.OnConnectionEvent += OnPlayerJoin();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsHost) return;
        RoomCode.text = TestRelay.joinCode;

        /*if (NetworkManager.Singleton.ConnectedClients != lastConnectedClients)
        {
            print("Clientlist changed");
            lastConnectedClients = NetworkManager.Singleton.ConnectedClients;
            PlayerConnectedClientRpc();
        }*/
    }
}
