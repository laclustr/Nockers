using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class StopwatchController : MonoBehaviour
{
    private bool isTimerRunning = false;
    private float elapsedTime = 0f;
    private float topScore = float.MaxValue;
    private string logFolderPath = "Logs";
    private string logFileName = "topscore.txt";
    private string logFilePath;

    private TextMeshProUGUI hudText;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        logFilePath = Path.Combine(logFolderPath, logFileName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            StartTimer();
        }
        else if (scene.name == "WinScene")
        {
            StopTimer();
            SaveTopScore();
        }
        else if (scene.name == "TitleScreen")
        {
            // Do nothing
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
        if (elapsedTime < topScore)
        {
            topScore = elapsedTime;
        }
    }

    private void UpdateHUD()
    {
        if (hudText == null)
        {
            hudText = FindObjectOfType<TextMeshProUGUI>();
        }

        if (hudText != null)
        {
            hudText.text = "Time: " + elapsedTime.ToString("F2");
        }
    }

    private void SaveTopScore()
    {
        string logDirectory = Path.Combine(Application.dataPath, logFolderPath);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        string fullLogFilePath = Path.Combine(logDirectory, logFileName);

        using (StreamWriter writer = new StreamWriter(fullLogFilePath))
        {
            writer.WriteLine("Top Score: " + topScore.ToString("F2"));
        }
    }
}
