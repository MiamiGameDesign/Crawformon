using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YogaMat : MonoBehaviour
{
    public AudioSource sound;
    public void OnPress()
    {
        sound.Play();
        AllTextOnScreen.currPHealth += 20;
    }
}
