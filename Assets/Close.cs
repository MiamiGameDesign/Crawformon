using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Close : MonoBehaviour
{
    public Image KrawDaddy;
    public GameObject button;
    public GameObject close;
    public AudioSource sound;
    public void OnPress()
    {
        sound.Play();
        KrawDaddy.enabled = false;
        button.SetActive(false);
        close.SetActive(false);
    }
}
