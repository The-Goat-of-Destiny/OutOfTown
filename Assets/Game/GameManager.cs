using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public List<Material> PlayerMats = new();

    void Awake()
    {
        Game.Manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    [ServerRpc]
    void PlayerJoinServerRpc(string _username = "Player", int _icon = 0, int _skin = 0)
    {
        Game.ConnectedPlayers.Add(new PlayerData(_username, _icon, _skin));
        UpdateConnectedPlayersClientRpc();
    }

    [ClientRpc]
    void UpdateConnectedPlayersClientRpc()
    {
        // Inform all clients about current ConnectedPlayers
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
