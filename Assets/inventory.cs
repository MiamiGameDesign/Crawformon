using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    public Image KrawDaddy;
    public GameObject button;
    public GameObject close;
    public void OnPress()
    {
        KrawDaddy.enabled = true;
        button.SetActive(true);
        close.SetActive(true);
    }
}
