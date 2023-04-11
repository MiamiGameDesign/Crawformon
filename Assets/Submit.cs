using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Submit : MonoBehaviour
{
    public Text playerName;
    // Start is called before the first frame update
    string name;
    public void onSubmit()
    {
        name = playerName.text;
        PlayerPrefs.SetString("Name", name);
        SceneManager.LoadScene("Battle");
    }
}
