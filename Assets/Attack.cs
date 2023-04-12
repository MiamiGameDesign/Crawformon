using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject KrawDaddy;
    string[] krawdaddyText =
     {
        "Kraw Daddy Used Slash",
        "Kraw Daddy Used Whip",
        "Kraw Daddy Used Deleted From Student Directory",
        "Kraw Daddy Used Suspend",
        "Kraw Daddy Used Expel"
    };
    //give player a certain amount of seconds to push a key
    public void OnPress()
    {
        GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
        if (AllTextOnScreen.currHealth > 0)
        AllTextOnScreen.currHealth -= (int)Random.Range(0, 10);
    }
}
