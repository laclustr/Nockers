using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopwatchController : MonoBehaviour
{
    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float topScore = Mathf.Infinity;
    private string logFileName = "top_score_log.txt";

    public GameObject hudText;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadTopScore();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            StartTimer();
        }
        else
        {
            StopTimer();
            if (scene.name == "WinScene")
            {
                SaveTopScore();
            }
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateHUD();
        }
    }

    private void StartTimer()
    {
        isTimerRunning = true;
        elapsedTime = 0f;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateHUD()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        string currentTime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        hudText.GetComponent<TextMesh>().text = "Time: " + currentTime;
    }

    private void LoadTopScore()
    {
        if (File.Exists(logFileName))
        {
            string[] lines = File.ReadAllLines(logFileName);
            if (lines.Length > 0)
            {
                if (float.TryParse(lines[0], out float savedTopScore))
                {
                    topScore = savedTopScore;
                }
            }
        }
    }

    private void SaveTopScore()
    {
        if (elapsedTime < topScore)
        {
            topScore = elapsedTime;
            File.WriteAllText(logFileName, topScore.ToString());
        }
    }
}
