using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject blackOutSquare;
    public Player_Movement movement;
    public Animator playerAnim;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            movement.enabled = false;
            playerAnim.enabled = true;
            StartCoroutine(FadeBlackOutSquare());
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        yield return new WaitForSeconds(2);
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while(blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                if(blackOutSquare.GetComponent<Image>().color.a >= 1)
                {
                    SceneManager.LoadScene (sceneName:"DeathScene");
                }
                yield return null;
            }
        }
    }
}
