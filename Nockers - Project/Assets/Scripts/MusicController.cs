using UnityEngine;

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
        PlayFirstSong();
    }

    void PlayFirstSong()
    {
        audioSource.clip = firstSong;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySecondSong()
    {
        audioSource.Stop();
        audioSource.clip = secondSong;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayFirstSongFromBeginning()
    {
        audioSource.Stop();
        audioSource.clip = firstSong;
        audioSource.loop = true;
        audioSource.Play();
    }
}
