using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject currentPlayer;
    [SerializeField] public GameObject gameManager;

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
        gameManager.GetComponent<PlayerMovement>().MoveToTarget();
    }
    public void InteractAction()
    {
        gameManager.GetComponent<PlayerMovement>().InteractWithObject();
    }
}
