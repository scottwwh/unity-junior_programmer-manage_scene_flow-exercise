using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField NameText;

    private string NameDefault = "Anonymous";
    private string Name = "";

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started!");
    }

    private void Update()
    {
        // Do nothing?
    }

    public void StartNew()
    {
        // Override default if not set
        if (NameText.text == "")
        {
            Name = NameDefault;
        } else {
            Name = NameText.text;
        }

        GameManager.Instance.Name = Name;

        SceneManager.LoadScene(1);
    }
}
