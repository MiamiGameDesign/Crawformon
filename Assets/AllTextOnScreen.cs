using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AllTextOnScreen : MonoBehaviour
{
    public GameObject playerHealth;
    public GameObject whatWillYouDo;
    public GameObject bossHealth;
    public Image youWinB;
    public GameObject youwinT;
    static public double currHealth = 100;
    static public double currPHealth = 100;
    static public double maxHealth = 100;
    public static GameObject healsLeft;
    public static string name;

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("Name");
        if (name.Equals(""))
            whatWillYouDo.GetComponent<Text>().text = "What will you do?";
        else
            whatWillYouDo.GetComponent<Text>().text = "What will " + name + " do?";
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth.GetComponent<Text>().text = "Kraw Daddy's Health: " + currHealth + "/" + maxHealth;
        playerHealth.GetComponent<Text>().text = "Player's Health: " + currPHealth + "/" + maxHealth;
        
        if (currPHealth >= 100) {
            currPHealth = 100;
        }
        if (currHealth <=0)
        {
            youWinB.enabled = true;
            youwinT.GetComponent<Text>().text = "YOU WIN!!!! :D";
            Time.timeScale = 0;
            StartCoroutine(crash());
        }
        if (currPHealth <=0)
        {
            youWinB.enabled = true;
            youwinT.GetComponent<Text>().text = "YOU LOSE!!!! D:";
            Time.timeScale = 0;
            StartCoroutine(crash());
        }
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("Main Menu");
    }
    IEnumerator crash()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

}
