using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelection : MonoBehaviour
{
    [SerializeField] private GameObject hair;
    [SerializeField] public List<GameObject> hairList = new List<GameObject>();

    private int currentHairIndex = 0;
    void Start()
    {
        currentHairIndex = 0;
        hairList[currentHairIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            if(currentHairIndex != hairList.Count - 1) 
            {
                RotateHair(1);
            }
            else
            {
                print("can't go any further up");
            }
        }

        if (Input.GetKeyDown("k"))
        {
            if (currentHairIndex > 0)
            {
                RotateHair(-1);
            }
            else
            {
                print("can't go any further down");
            }
        }
    }

    void RotateHair(int direction)
    {
        hairList[currentHairIndex].SetActive(false);
        currentHairIndex = currentHairIndex + direction;
        hairList[currentHairIndex].SetActive(true);
    }
}
