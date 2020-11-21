using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;
    float m_spawnTime;
    int isScore;
    bool isGameover;
    UIManager m_UI;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_UI = FindObjectOfType<UIManager>();
        m_UI.SetScoreText("Score: " + isScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameover)
        {
            m_spawnTime = 0;
            m_UI.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime<=0)
        {
            SpawnOstacle();
            m_spawnTime = spawnTime;
        }
    }
    public void SpawnOstacle()
    {
        float randYpos = Random.Range(-2.75f, -1f);
        Vector2 spawnPos = new Vector2(11, randYpos);
        if(obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void SetScore( int value )
    {
        isScore = value;
    }
    public int GetScore()
    {
        return isScore;
    }
    public void ScroreIncrement()
    {
        isScore++;
        m_UI.SetScoreText("Score: " + isScore);
    }
    public bool IsGameover()
    {
        return isGameover;
    }
    public void SetGameoverState(bool state)
    {
        isGameover = state;
    }
}
