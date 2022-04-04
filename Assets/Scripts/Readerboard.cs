using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Readerboard : MonoBehaviour
{
    public float timePerLetter;
    public string[] message;
    public TextMeshProUGUI text;
    public AudioSource audioSource;
    public Animator head;
    public LevelManager levelManager;

    int positionInText = 0;
    bool canAdvanceText = false;

    private void Start()
    {
        StartCoroutine(Readout());
    }

    public void AdvanceText(InputAction.CallbackContext context)
    {
        if (context.performed && canAdvanceText)
        {
            positionInText++;
            canAdvanceText = false;

            if (positionInText == message.Length)
            {
                if (levelManager.currentLevel == "Quit")
                {
                    Application.Quit();
                } else
                {
                    SceneManager.LoadScene(levelManager.currentLevel);
                }
            }
            else
            {
                StartCoroutine(Readout());
            }
        }
    }


    IEnumerator Readout()
    {
        head.SetTrigger("restart");
        for (int i = 0; i < message[positionInText].Length; i++)
        {
            text.text = message[positionInText].Substring(0, i+1);
            if (message[positionInText][i] != " "[0])
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(timePerLetter);
        }
        canAdvanceText = true;
    }
}
