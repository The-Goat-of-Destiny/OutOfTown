using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : NetworkBehaviour
{
    public GameObject PlayerPrefab;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        //NetworkManager.Singleton.SpawnManager.InstantiateAndSpawn(PlayerPrefab, NetworkManager.Singleton.LocalClientId)
        //SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
        SpawnPlayersServerRpc();
        //Instantiate(PlayerPrefab, transform.position, transform.rotation).GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //print("IsOwner: " + IsServer.ToString());
        //GetComponent<NetworkObject>().Spawn();// SpawnWithOwnership(NetworkManager.Singleton.LocalClientId);
        //if (IsServer) SpawnPlayersServerRpc();
        //SetupPlayerSpawnerServerRpc();
        //GetComponent<NetworkObject>().SpawnWithOwnership(NetworkManager.Singleton.LocalClientId);
        //GetComponent<NetworkObject>().Spawn();
        //Instantiate(PlayerPrefab, transform.position, transform.rotation).GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
    }

    [ServerRpc]
    void SpawnPlayerServerRpc(ulong clientId)
    {
        Instantiate(PlayerPrefab, transform.position, transform.rotation).GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }



    [ServerRpc]
    void SpawnPlayersServerRpc()
    {
        foreach (ulong clientId in NetworkManager.Singleton.ConnectedClientsIds)
        {
            print("Spawning client " + clientId.ToString());
            Instantiate(PlayerPrefab, transform.position, transform.rotation).GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
