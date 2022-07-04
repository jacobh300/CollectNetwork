using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginModal : MonoBehaviour
{
    
    public Button loginButton;
    public Button registerButton;
    public Web web;

    //User input fields
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;


    public void disable()
    {
        this.gameObject.SetActive(false);
    }

    public void enable()
    {
        this.gameObject.SetActive(true);
    }

    private void OnEnable()
    {

        loginButton.onClick.AddListener(() => web.LoginUserRequest(usernameField.text, passwordField.text));
        registerButton.onClick.AddListener(() => web.RegisterUserRequest(usernameField.text, passwordField.text));
    }

    private void OnDisable()
    {
        loginButton.onClick.RemoveAllListeners();
        registerButton.onClick.RemoveAllListeners();
    }

}
