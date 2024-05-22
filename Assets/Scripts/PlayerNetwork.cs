using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public PlayerMovement Movement;

    public List<MeshRenderer> Meshes = new();

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            foreach (MeshRenderer mesh in Meshes)
            {
                mesh.enabled = false;
            }
        }
        else
        {
            Destroy(Movement);
        }
    }

    //private NetworkVariable<int> randomNumber = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);


    /*public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (int previousValue, int newValue) =>
        {
            Debug.Log(OwnerClientId + "; randomNumber " + randomNumber.Value);
        };
    }*/

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /*if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }*/
    }
}
