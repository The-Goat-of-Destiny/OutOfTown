using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlayerNetwork : NetworkBehaviour
{
    public PlayerMovement Movement;
    public Camera Camera;

    public TMP_Text Nametag;

    public List<MeshRenderer> Meshes = new();

    public override void OnNetworkSpawn()
    {
        if (Nametag) Nametag.text = "Player #" + OwnerClientId.ToString();// TODO: Replace with Username
        if (IsOwner)
        {
            Game.Player = this;
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

    void Start()
    {
        Material[] mats = new Material[1];
        mats[0] = Game.Manager.PlayerMats[(int)OwnerClientId];

        Meshes[0].gameObject.GetComponent<MeshRenderer>().materials = mats;
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
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        /*if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }*/
    }
}
