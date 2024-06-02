using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private TMP_Text Username;
    [SerializeField] int userIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateVisuals(string clientUsername)
    {
        if (NetworkManager.Singleton.ConnectedClientsIds.Count > userIndex)
        {
            Username.text = clientUsername;
            //Username.text = Game.ConnectedPlayers[userIndex].Username;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
