using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")) //if esc + no menu
        {
            menu.SetActive(!menu.activeSelf);
        }
        if(menu.activeSelf)
        {
            //eeee
        }

    }
     public void QuitAplication()
    {
        print("close game"); //add a "are you sure?" screen"
        Application.Quit();
    }

    public void startScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void characterGen()
    {
        SceneManager.LoadScene("CharacterGen");
    }
}
