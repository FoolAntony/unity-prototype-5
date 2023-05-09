using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pauseText;
    public Button restrartButton;
    public bool isGameActive;
    private int score;
    private int lives;
    public GameObject titleScreen;
    public GameObject slider;
    public bool pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseScene();
        }
    }
    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        restrartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseScene()
    {
            if(!pauseGame)
            {
                isGameActive = false;
                Time.timeScale = 0;
                pauseText.gameObject.SetActive(true);
                pauseGame = true;
            }
            else if(pauseGame)
            {
                isGameActive = true;
                Time.timeScale = 1;
                pauseText.gameObject.SetActive(false);
                pauseGame = false;
            }

    }

    public void StartGame(float difficulty)
    {
        isGameActive = true;
        pauseGame = false;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTargets());
        score = 0;
        lives = 3;
        UpdateScore(score);
        UpdateLive(lives);
        titleScreen.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }

    public void LivesCounter()
    {
        if(lives > 0)
        {
            lives--;
            UpdateLive(lives);
        }
        else
        {
            GameOver();
        }
    }
    public void UpdateLive(int liveLeft)
    {
        livesText.text = "Lives: " + liveLeft;
    }

}
