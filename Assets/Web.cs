using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{




    public void RegisterUserRequest(string username, string password)
    {
        StartCoroutine(RegisterUser(username, password));
    }

    public void LoginUserRequest(string username, string password)
    {
        StartCoroutine(Login(username, password));
    }

    public void GetUserItemsRequest(string userID, System.Action<string> callback)
    {
        StartCoroutine(GetUserItems(userID, callback));
    }

    public void GetItemRequest(string itemID, System.Action<string> callback)
    {
        StartCoroutine(GetItem(itemID, callback));
    }


    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Succesful login
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text != "failed") { 
                    Main.instance.UserInfo.SetCredentials(username, password);

                    Main.instance.UserInfo.SetID(www.downloadHandler.text);
                    Main.instance.loginModal.disable();
                    Main.instance.profileModal.enable();

                }
            }
        }
    }

    IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                Main.instance.UserInfo.SetCredentials(username, password);
                

                Main.instance.UserInfo.SetID(www.downloadHandler.text);
                Main.instance.loginModal.disable();
                Main.instance.profileModal.enable();

            }
        }
    }


    IEnumerator GetUserItems(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/GetUserItems.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }


    IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityBackend/GetItem.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }


}
