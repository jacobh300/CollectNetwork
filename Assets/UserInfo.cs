using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{

    public string UserID { get; private set; }
    [SerializeField]
    public string UserName { get; private set; }
    [SerializeField]
    string UserPassword;

   public void SetCredentials(string username, string userpass)
    {
        UserName = username; 
        UserPassword = userpass;
    }

    public void SetID(string id)
    {
        UserID = id; 
    }

}
