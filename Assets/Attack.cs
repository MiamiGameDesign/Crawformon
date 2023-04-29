using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject prompt;
    public Button attackButton, inventoryButton;
    private char randomLetter;
    private float timeLimit = 2.0f;
    private float startTime, random;
    private int damage;
    int index;
    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private string[] krawdaddyText =
    {
        "Kraw Daddy embezzled your tuition!",
        "Kraw Daddy deleted you from the Student Directory!",
        "Kraw Daddy suspended you!",
        "Kraw Daddy expelled you!",
        "Kraw Daddy gave you probation for four years!",
        "Kraw Daddy revoked your degree!",
        "Kraw Daddy fined you your entire tution's worth!",
        "Kraw Daddy barred you from all of the bars in Oxford!",
        "Kraw Daddy forced you to take 18 credit hours!",
        "Kraw Daddy forced you to step on the Seal!"
    };

    public AudioSource attackSound;
    public AudioSource press;
    public AudioSource missed;
    public void OnPress()
    {
        StartTimer(4.75f);
        index = (int)Random.Range(0, alpha.Length);
        randomLetter = alpha[index];
        press.Play();
        prompt.SetActive(true);
        prompt.GetComponent<Text>().text = "Press " + randomLetter + " to hurt Kraw Daddy!";
        startTime = Time.time;
        StartCoroutine(WaitForKeyPress(4.75f));
        
        
    }
    public void StartTimer(float turnTime)
    {
        StartCoroutine(TimeoutEndTurnButton(turnTime));
        if (turnTime == 2)
        {
            prompt.SetActive(true);
            prompt.GetComponent<Text>().text = "";
            StartCoroutine(KrawDaddyAttack(turnTime));
        }
            
    }
    public IEnumerator TimeoutEndTurnButton(float turnTime)
    {
        attackButton.interactable = false;
        inventoryButton.interactable = false;
        yield return new WaitForSeconds(turnTime);
        inventoryButton.interactable = true;
        attackButton.interactable = true;
    }
    private IEnumerator WaitForKeyPress(float turnTime)
    {
        while (Time.time < startTime + timeLimit)
        {
            if (Input.anyKeyDown)
            {
                char pressedKey = Input.inputString.ToLower()[0];
                if (pressedKey == char.ToLower(randomLetter))
                {
                    attackSound.Play();
                    damage = (int)Random.Range(1, 10);
                    prompt.GetComponent<Text>().text = "Hit! You dealt " + damage + " damage to Kraw Daddy!";
                    AllTextOnScreen.currHealth -= damage;
                    yield return new WaitForSeconds((float)1.5);
                    
                    StartCoroutine(KrawDaddyAttack(turnTime));
                }
                else
                {
                    missed.Play();
                    prompt.GetComponent<Text>().text = "You Missed!";
                    yield return new WaitForSeconds((float)1.5);
                    StartCoroutine(KrawDaddyAttack(turnTime));
                }
                yield break;
            }
            yield return null;
        }
        missed.Play();
        prompt.GetComponent<Text>().text = "You Missed!";
        yield return new WaitForSeconds((float)1.5);
        StartCoroutine(KrawDaddyAttack(turnTime));
    }

    public IEnumerator KrawDaddyAttack(float turnTime)
    {
        if (turnTime == 2)
            yield return new WaitForSeconds(.75f);
        GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = krawdaddyText[Random.Range(0, krawdaddyText.Length)];
        if (AllTextOnScreen.currPHealth > 0)
        {
            if (Random.value < .15)
            {
                damage = 0;
            } else
            {
                damage = (int)Random.Range(0, 16);
            }
            
            AllTextOnScreen.currPHealth -= damage;
            if (damage == 0)
            {
                missed.Play();
                prompt.GetComponent<Text>().text = "Kraw Daddy missed!";
                yield return new WaitForSeconds((float)1.5);
            }
            else
            {
                attackSound.Play();
                prompt.GetComponent<Text>().text = "Hit! Kraw Daddy dealt " + damage + " damage!";
                yield return new WaitForSeconds((float)1.5);
            }
            prompt.SetActive(false);
            GameObject.FindWithTag("KrawDaddy").GetComponent<Text>().text = "";
        }
    }

}
