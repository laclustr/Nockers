using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    public AudioClip firstSong;
    public AudioClip secondSong;

    private AudioSource audioSource;

    private static MusicController instance; // Singleton instance

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Make the GameObject persistent across scenes

        audioSource = GetComponent<AudioSource>();
        PlayCorrectSong();
    }

    void PlayCorrectSong()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "WinScene" || sceneName == "TitleScreen")
        {
            PlayFirstSong();
        }
        else
        {
            PlaySecondSong();
        }
    }

    void PlayFirstSong()
    {
        audioSource.Stop();
        audioSource.clip = firstSong;
        audioSource.loop = true;
        audioSource.Play();
    }

    void PlaySecondSong()
    {
        audioSource.Stop();
        audioSource.clip = secondSong;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayCorrectSong();
    }
}
