using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HardModeGameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text hardModeText;

    private bool gameOver;
    private bool restart;
    private bool hasPlayed;
    private int points;
    private bool hardMode;

    public AudioClip MusicClipOne;
    public AudioSource MusicSource;

    public string NewLine { get; private set; }

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        points = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());


    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("_Scenes");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();

        if (hardMode)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("_Hard_Mode_Scene");
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'L' to restart level";
                hardModeText.text = "Press 'H' to enter Hard Mode";
                restart = true;
                hardMode = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        points += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + points;
        if (points >= 100)
        {
            gameOverText.text = "You Win! Game Created By Cody Bolton";
            gameOver = true;
            restart = true;
            if (!hasPlayed)
            {
                MusicSource.clip = MusicClipOne;
                MusicSource.Play();
                hasPlayed = true;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
