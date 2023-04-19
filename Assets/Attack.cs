using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    string[] krawdaddyText =
     {
        "Kraw Daddy Used Slash",
        "Kraw Daddy Used Whip",
        "Kraw Daddy Used Deleted From Student Directory",
        "Kraw Daddy Used Suspend",
        "Kraw Daddy Used Expel"
    };

    public AudioSource sound;

    //give player a certain amount of seconds to push a key
    //make battle start be greg crawford just saying his name really slowly
    public void OnPress()
    {
        sound.Play();
        GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
        if (AllTextOnScreen.currHealth > 0)
        AllTextOnScreen.currHealth -= (int)Random.Range(0, 10);

        if (AllTextOnScreen.currPHealth > 0)
        AllTextOnScreen.currPHealth -= (int)Random.Range(0, 10);
    }

    

}
