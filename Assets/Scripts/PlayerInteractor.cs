using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public LayerMask InteractableMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3f, InteractableMask);
        if (hit.collider)
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.OnInteract();
                }
            }
        }
    }
}
