using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] public AnimationClip animToPlay;
    [SerializeField] public GameObject gameManager;
    public GameObject player;

    private void Start()
    {
        player = gameManager.GetComponent<PlayerMovement>().currentPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            player = gameManager.GetComponent<PlayerMovement>().currentPlayer;
            player.GetComponent<PlayerMovement>().ArrivedAtObject(animToPlay);

            gameObject.SetActive(false);
        }
    }
}
