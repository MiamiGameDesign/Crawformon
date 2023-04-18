using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    
    // Start is called before the first frame update
    void Start()
    {
        whatWillYouDo.GetComponent<Text>().text = "What will " + PlayerPrefs.GetString("Name") + " do?";
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth.GetComponent<Text>().text = "Crawford's Health: " + currHealth + "/" + maxHealth;
        playerHealth.GetComponent<Text>().text = "Player's Health: " + currPHealth + "/" + maxHealth;
        if (currHealth <=0)
        {
            youWinB.enabled = true;
            youwinT.GetComponent<Text>().text = "YOU WIN!!!! :D";
        }
        if (currPHealth <=0)
        {
            youWinB.enabled = true;
            youwinT.GetComponent<Text>().text = "YOU Lose!!!! D:";
        }
    }
}
