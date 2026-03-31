using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Carryable HeldItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grab(Carryable item)
    {
        HeldItem = item;
        item.transform.parent = Camera.main.transform;
        item.transform.SetLocalPositionAndRotation(Vector3.forward - Vector3.up * 0.5f, Quaternion.identity);
        item.gameObject.layer = LayerMask.NameToLayer("Overlay");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
