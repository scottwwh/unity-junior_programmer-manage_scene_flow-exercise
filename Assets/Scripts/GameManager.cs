using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    // public static GameManager Instance { get; private set; }
    public static GameManager Instance;

    public LeaderboardScore HighScore;
    public LeaderboardScore SessionScore;

    private void Awake()
    {
        Debug.Log("Initialize GameManager");
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }    
        // else     
        // {
        //     Destroy(gameObject);
        // }
        
        // LoadDefaults();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void InitSessionScore(string name)
    {
        // Provide default value
        name = (name == "") ? "Anonymous" : name ;
        SessionScore = new LeaderboardScore();
        SessionScore.Name = name;
        SessionScore.Points = 0;
    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(HighScore);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LeaderboardScore data = JsonUtility.FromJson<LeaderboardScore>(json);

            HighScore = data;
        } else {
            Debug.Log("Could not load from disk, provide defaults");
            HighScore = new LeaderboardScore();
            HighScore.Name = "Ed Funk";
            HighScore.Points = -1;
        }
    }
}