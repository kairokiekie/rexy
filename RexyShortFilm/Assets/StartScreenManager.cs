using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject profileSelection;
    [SerializeField] private GameObject logInPage;
    [SerializeField] private Text userText;
    [SerializeField] private String protoScene;
    // Start is called before the first frame update
    void Start()
    {
        profileSelection.SetActive(true);
        logInPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginButton(string name) //wrapper for the UI button
    {
        StartCoroutine(SwapToLoginScreen(name));
    }
    IEnumerator SwapToLoginScreen(string _name)
    {
        yield return new WaitForSeconds(.2f);
        userText.text = _name;
        profileSelection.SetActive(false);
        logInPage.SetActive(true);
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(protoScene);
    }
}
