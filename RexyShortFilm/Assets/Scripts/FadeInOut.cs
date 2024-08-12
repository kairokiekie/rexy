using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Security;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Material ghostMat;
    [SerializeField] private float desiredValue = 0.6f;

    [SerializeField] private float speed = 1f;
    private UnityEngine.Color ghostColour;
    // Start is called before the first frame update

    private void Start()
    {
        ghostColour = ghostMat.color;
        ghostColour = new UnityEngine.Color(0.2f, 0.64f, 0.72f, 0.0f);
        ghostMat.color = ghostColour;

    }
    public IEnumerator FadeIn()
    {
        
        while (ghostColour.a < desiredValue)
        {
            ghostColour.a += 0.05f;
            ghostMat.color = ghostColour;

            yield return new WaitForSeconds(speed);
        }
    }

    public IEnumerator FadeOut()
    {

        while (ghostColour.a > 0)
        {
            ghostColour.a -= 0.05f;
            ghostMat.color = ghostColour;

            yield return new WaitForSeconds(speed);
        }
        this.gameObject.SetActive(false);
    }
}
