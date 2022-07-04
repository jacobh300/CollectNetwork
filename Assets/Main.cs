using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{

    public static Main instance;

    public Web Web;
    public UserInfo UserInfo;

    public LoginModal loginModal;
    public ProfileModal profileModal;

    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        UserInfo = GetComponent<UserInfo>();

        loginModal.gameObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
