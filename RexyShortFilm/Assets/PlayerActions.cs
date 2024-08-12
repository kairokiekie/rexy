using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject currentPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveAction()
    {
        currentPlayer.GetComponent<PlayerMovement>().MoveToTarget();
    }
    public void InteractAction()
    {
        currentPlayer.GetComponent<PlayerMovement>().InteractWithObject();
    }
    public void SwitchPlayer(GameObject newPlayer)
    {
        currentPlayer = newPlayer;
    }
}
