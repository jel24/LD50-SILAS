using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject[] onOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            foreach (GameObject o in onOff)
            {
                o.SetActive(!o.activeSelf);
            }
        }
    }

}
