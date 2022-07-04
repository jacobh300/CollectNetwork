using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ProfileModal : MonoBehaviour
{


    public TMP_Text usernameField;
    public TMP_Text userIDField;

    [SerializeField]
    GameObject itemGroup;

    Action<string> _createItemsCallBack;

    [Serializable]
    public class UserItems {
        public string userID;
        public string itemID;

    }

    [Serializable]
    public class Item {
        public string name;
        public string description;
    }


    private void OnEnable()
    {
        usernameField.text = Main.instance.UserInfo.UserName;
        userIDField.text = Main.instance.UserInfo.UserID;
        
    }

    public void enable()
    {
        this.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallBack = (jsonArray) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArray));
        };

        CreateItems();
    }

    public void CreateItems()
    {
        string userID = Main.instance.UserInfo.UserID;
        Main.instance.Web.GetUserItemsRequest(userID, _createItemsCallBack);
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
       
        //Parse json array string as an array
        UserItems[] userItems = JsonHelper.FromJson<UserItems>("{\"Items\":" + jsonArrayString + "}");
        if(userItems != null) { 
            foreach(UserItems userItem in userItems)
            {
                bool isDone = false; //done dowloading?
                string itemId = userItem.itemID;
                Item item = new Item();
           

                //Create a call back to get information from Web.cs
                Action<string> getItemInfoCallback = (itemInfo) =>
                {
                    isDone = true;
                    JsonUtility.FromJsonOverwrite(itemInfo.Substring(1, itemInfo.Length-2), item);
                    //Item tempItem = JsonUtility.FromJson<Item>( itemInfo.Substring(1, itemInfo.Length-2) );
             
                };

                Main.instance.Web.GetItemRequest(itemId, getItemInfoCallback);
                //Wait until the callback is called from the Web (info finished downloading)
                yield return new WaitUntil(() => isDone == true);

                //Instaniate Gameobject
                GameObject itemGO = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
                itemGO.transform.SetParent(itemGroup.transform);
                itemGO.transform.localScale = Vector3.one;
                itemGO.transform.localPosition = Vector3.zero;
                //Fill information
                itemGO.transform.Find("ItemName").GetComponent<TMP_Text>().text = item.name;
                itemGO.transform.Find("ItemDescription").GetComponent<TMP_Text>().text = item.description;

                //Continue to the next item

            }
        }
    }

}
