using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WhatWillYouDo : MonoBehaviour
{
    public GameObject textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox.GetComponent<Text>().text = "What will " + PlayerPrefs.GetString("Name") + " do?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
