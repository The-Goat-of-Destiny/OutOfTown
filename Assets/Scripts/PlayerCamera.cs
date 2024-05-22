using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerCamera : NetworkBehaviour
{
    private float cameraAxisX;
    private float cameraAxisY;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraAxisX -= Input.GetAxis("Mouse Y");
        cameraAxisY += Input.GetAxis("Mouse X");

        // Rotate camera based on mouse.
        cameraAxisX = Mathf.Clamp(cameraAxisX, -90, 90); // limits vertical rotation
        transform.localEulerAngles = Vector3.right * cameraAxisX;
        transform.parent.localEulerAngles = Vector3.up * cameraAxisY;
    }
}
