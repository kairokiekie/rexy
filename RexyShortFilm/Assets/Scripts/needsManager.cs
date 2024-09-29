using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class needsManager : MonoBehaviour
{
    [SerializeField] private Slider thisSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisSlider.value -= 0.001f;
    }
}
