using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject prompt;
    private char randomLetter;
    private float timeLimit = 1.0f;
    private float startTime;
    private int damage;
    int index;
    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private string[] krawdaddyText =
    {
        "Kraw Daddy Used Slash",
        "Kraw Daddy Used Whip",
        "Kraw Daddy Used Deleted From Student Directory",
        "Kraw Daddy Used Suspend",
        "Kraw Daddy Used Expel"
    };

    public AudioSource attackSound;
    public AudioSource press;
    public void OnPress()
    {
        index = (int)Random.Range(0, alpha.Length);
        randomLetter = alpha[index];
        press.Play();
        prompt.SetActive(true);
        prompt.GetComponent<Text>().text = "Press " + randomLetter + " in order to hurt Crawdaddy!";
        startTime = Time.time;
        StartCoroutine(WaitForKeyPress());
    }

    private IEnumerator WaitForKeyPress()
    {
        while (Time.time < startTime + timeLimit)
        {
            if (Input.anyKeyDown)
            {
                char pressedKey = Input.inputString.ToLower()[0];
                Debug.Log(pressedKey == char.ToLower(randomLetter));
                if (pressedKey == char.ToLower(randomLetter))
                {
                    attackSound.Play();
                    damage = (int)Random.Range(0, 10);
                    prompt.GetComponent<Text>().text = "Hit! You dealt " + damage + " damage to Crawdaddy!";
                    AllTextOnScreen.currHealth -= damage;
                    yield return new WaitForSeconds((float)1.5);
                    prompt.SetActive(false);
                    GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
                    if (AllTextOnScreen.currPHealth > 0)
                        AllTextOnScreen.currPHealth -= (int)Random.Range(0, 10);
                }
                else
                {
                    prompt.GetComponent<Text>().text = "You Missed!";
                    yield return new WaitForSeconds((float)1.5);
                    prompt.SetActive(false);
                    GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
                    if (AllTextOnScreen.currPHealth > 0)
                        AllTextOnScreen.currPHealth -= (int)Random.Range(0, 10);
                }
                yield break;
            }
            yield return null;
        }
        prompt.GetComponent<Text>().text = "You Missed!";
        yield return new WaitForSeconds((float)1.5);
        prompt.SetActive(false);
        GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
        if (AllTextOnScreen.currPHealth > 0)
            AllTextOnScreen.currPHealth -= (int)Random.Range(0, 10);
    }
}
