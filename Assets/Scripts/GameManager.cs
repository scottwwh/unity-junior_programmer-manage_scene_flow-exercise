using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    // public static GameManager Instance { get; private set; }
    public static GameManager Instance;

    public string Name;
    public int HighScore;

    private void Awake()
    {
        // Debug.Log("fe");
        // if (Instance == null)
        // {
        //     Debug.Log("fi");
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }    
        // else     
        // {
        //     Debug.Log("fo");
        //     Destroy(gameObject);
        // }
        
        // LoadDefaults();
        // Debug.Log("fum");

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadDefaults();
    }

    public void LoadDefaults() {
        Name = "Anonymous";
        HighScore = 0;
    }

    public void Beep() {
        Debug.Log("Beep");
    }
}