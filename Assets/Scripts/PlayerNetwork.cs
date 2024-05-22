using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public float Speed = 10f;

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
    }

    //private NetworkVariable<int> randomNumber = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public CharacterController Controller;

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

        /*if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }*/
        Vector3 moveAxis = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        moveAxis.Normalize();

        Controller.Move(Speed * Time.deltaTime * moveAxis);
    }
}
