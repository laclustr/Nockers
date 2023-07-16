using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        // Restart the game or load the desired scene
        SceneManager.LoadScene("YourGameScene");
    }
}