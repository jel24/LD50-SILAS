using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public LevelManager levelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(600, 600, false);
        levelManager.currentLevel = "Labyrinth-1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
