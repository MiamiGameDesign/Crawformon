using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YogaMat : MonoBehaviour
{
    public AudioSource sound;
    public GameObject healsLeft;
    public static int numLeft = 3;
    Attack a;
    public void Start()
    {
        a = GameObject.FindObjectOfType<Attack>();
    }
    public void OnPress()
    {
        if (numLeft > 0 && AllTextOnScreen.currPHealth <80)
        {
            sound.Play();
            AllTextOnScreen.currPHealth += 20;
            numLeft--;
            a.StartTimer(2);
        } else if (numLeft > 0 && (AllTextOnScreen.currPHealth >= 80 && AllTextOnScreen.currPHealth < 100))
        {
            sound.Play();
            AllTextOnScreen.currPHealth += (100 - AllTextOnScreen.currPHealth);
            numLeft--;
            a.StartTimer(2);
        }
        
    }
    public void onHover() {
        healsLeft.SetActive(true);
        healsLeft.GetComponent<Text>().text = "Heals the player 20 health. Yoga Mats Left: " + YogaMat.numLeft;
    }
    public void onExit()
    {
        healsLeft.SetActive(false);
    }
}
