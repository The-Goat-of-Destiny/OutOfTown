using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TheFunnyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ServerRpc]
    public void BoopServerRpc()
    {
        BoopClientRpc();
    }

    [ClientRpc]
    public void BoopClientRpc()
    {
        Game.Player.Movement.Velocity.y = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
