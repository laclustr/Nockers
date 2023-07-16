using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorHider : MonoBehaviour
{
    public void LoadSampleScene()
    {
        Cursor.visible = false; // Hide the mouse cursor
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Cursor.visible = true; // Show the mouse cursor when the scene is loaded
    }
}
