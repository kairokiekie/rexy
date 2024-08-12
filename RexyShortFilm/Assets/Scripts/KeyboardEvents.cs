using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyboardEvents : MonoBehaviour
{
    [SerializeField] private GameObject rob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            rob.SetActive(true);
            StartCoroutine(rob.GetComponent<FadeInOut>().FadeIn());
        }

        if (Input.GetKeyDown("h"))
        {
            StartCoroutine(rob.GetComponent<FadeInOut>().FadeOut());
        }
    }
}
