using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    public Image KrawDaddy;
    public GameObject button;
    public GameObject close;
    public AudioSource sound;
    public GameObject healsLeft;

    public void OnPress()
    {

        sound.Play();
        KrawDaddy.enabled = true;
        button.SetActive(true);
        close.SetActive(true);
    }
}
