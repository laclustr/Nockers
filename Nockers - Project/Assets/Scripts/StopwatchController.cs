using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class StopwatchController : MonoBehaviour
{
    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float topScore = float.MaxValue;
    private string logFolderPath = "StopwatchLogs";
    private string logFileName = "topscore.txt";
    private string logFilePath;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        logFilePath = Path.Combine(logFolderPath, logFileName);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateHUD();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            StartTimer();
        }
        else if (scene.name == "WinScene" && SceneManager.GetActiveScene().name == "WinScene")
        {
            SaveTopScore();
            StopTimer();
            elapsedTime = 0f; // Reset the timer after logging the top score
        }
        else if (scene.name == "TitleScreen")
        {
            // Do nothing
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
        if (elapsedTime < topScore)
        {
            topScore = elapsedTime;
        }
    }

    private void UpdateHUD()
    {
        TextMeshProUGUI hudText = FindObjectOfType<TextMeshProUGUI>();
        if (hudText != null)
        {
            hudText.text = "Time: " + elapsedTime.ToString("F2");
        }
    }

    private void SaveTopScore()
    {
        Debug.Log("Log File Path: " + logFilePath);

        Debug.Log("Log File Path: " + logFilePath);
        string logDirectory = Path.Combine(Application.persistentDataPath, logFolderPath);
        string fullLogFilePath = Path.Combine(logDirectory, logFileName);

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
            Debug.Log("Log File Path: " + logFilePath);

        }

        if (!File.Exists(fullLogFilePath))
        {
            Debug.Log("Log File Path: " + logFilePath);
            // Create a new log file with initial top score
            using (StreamWriter writer = new StreamWriter(fullLogFilePath))
            {
                writer.WriteLine("Top Score: 999999.99");
                Debug.Log("Log File Path: " + logFilePath);
            }
        }

        string[] logLines = File.ReadAllLines(fullLogFilePath);

        if (logLines.Length >= 1)
        {
            Debug.Log("Log File Path: " + logFilePath);
            string topScoreLine = logLines[0];
            string[] topScoreParts = topScoreLine.Split(' ');
            float existingTopScore;

            if (float.TryParse(topScoreParts[2], out existingTopScore))
            {
                Debug.Log("Log File Path: " + logFilePath);
                if (elapsedTime < existingTopScore)
                {
                    Debug.Log("Log File Path: " + fullLogFilePath);
                    topScore = elapsedTime;

                    // Overwrite the log file with the current top score
                    using (StreamWriter writer = new StreamWriter(fullLogFilePath))
                    {
                        Debug.Log("Log File Path: " + fullLogFilePath);
                        writer.WriteLine("Top Score: " + topScore.ToString("F2"));
                    }
                }

            }
        }
    }
}