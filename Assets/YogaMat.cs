using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YogaMat : MonoBehaviour
{
    public AudioSource sound;
    public GameObject healsLeft;
    public static int numLeft = 3;
    public void OnPress()
    {
        if (numLeft > 0 && AllTextOnScreen.currPHealth < 100)
        {
            sound.Play();
            AllTextOnScreen.currPHealth += 20;
            numLeft--;
            
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
