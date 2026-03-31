using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : MonoBehaviour
{
    public List<GameObject> ModelComponents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grab()
    {
        if (!Game.Player.Inventory.HeldItem)
        {
            Game.Player.Inventory.Grab(this);
            foreach (GameObject t in ModelComponents)
            {
                t.layer = LayerMask.NameToLayer("Overlay");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
