using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}