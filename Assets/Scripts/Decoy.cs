using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoy : MonoBehaviour
{

    public AudioSource audioSource;

    public void SetToPlayerPosition()
    {
        transform.position = FindObjectOfType<PlayerController>().transform.position;
        audioSource.Play();
    }

    public void RemoveDecoy()
    {
        transform.position = new Vector2(10000f, 10000f);
        audioSource.Play();
    }


}
