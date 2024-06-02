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
        SpawnPlayersServerRpc();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ServerRpc(RequireOwnership = false)]
    void SpawnPlayersServerRpc()
    {
        if (!IsServer) return;
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
