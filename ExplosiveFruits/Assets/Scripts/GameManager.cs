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
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public bool isGameActive;
    public Button restartBtn;
    public GameObject titlePage;
    public TextMeshProUGUI livesText;
    private int lives;
    public GameObject pauseScreen;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame(int difficulty1)
    {
        isGameActive = true;
        spawnRate /= difficulty1;
        StartCoroutine(SpawnTargets());
        score = 0;
        //UpdateScore(0);
        titlePage.SetActive(false);
        UpdateLives(3);

    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){

            ChangePaused();
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

    public void UpdateLives (int livesToChange)
    {
        lives += livesToChange;
        livesText.text = "Lives: " + lives;

        if (lives < 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartBtn.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
