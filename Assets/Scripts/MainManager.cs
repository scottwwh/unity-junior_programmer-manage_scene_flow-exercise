using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// [DefaultExecutionOrder(1000)]
public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    
    private int m_Points;
    private bool m_Started = false;
    private bool m_GameOver = false;
    
    private string Name = "Anonymous";
    private int HighScore = -1;

    private string BestScoreName = "Eddy Funk";
    private int BestScorePoints = 10000;

    
    // Start is called before the first frame update
    //
    // TBD: Is this why the GameManager check below fails?
    void Start()
    {
        // TBD: How do I access GameManager (or any singleton/monobehaviour/etc) if it isn't attached to a scene?
        if (GameManager.Instance != null)
        {
            GameManager.Instance.Beep();
            Name = GameManager.Instance.Name;
            HighScore = GameManager.Instance.HighScore;
        } else {
            Debug.Log("Skipped directly to the game, cannot retrieve high score and name");
        }

        updateScoreText();
        updateBestScoreText();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        updateScoreText();
    }

    void updateScoreText() {
        ScoreText.text = $"{Name}'s score : {m_Points}";
    }

    void updateBestScoreText() {
        BestScoreText.text = $"{BestScoreName}'s score : {BestScorePoints}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
