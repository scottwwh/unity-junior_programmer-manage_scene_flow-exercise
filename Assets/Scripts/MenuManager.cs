using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField NameText;

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
        // Debug.Log("Initialize session score");
        GameManager.Instance.InitSessionScore(NameText.text);

        SceneManager.LoadScene(1);
    }
}
