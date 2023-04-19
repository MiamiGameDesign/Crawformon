using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YogaMat : MonoBehaviour
{
    public AudioSource sound;
    public GameObject healsLeft;
    public static int numLeft = 3;
    public void OnPress()
    {
        if (numLeft > 0)
        {
            sound.Play();
            AllTextOnScreen.currPHealth += 20;
            numLeft--;
            
        }
        
    }
}
