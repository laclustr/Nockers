using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject controlsPanel;
    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowControls()
    {
        // Implement your logic to show the controls screen
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    public void ExitGame(bool show)
    {
        Application.Quit();
    }
}
