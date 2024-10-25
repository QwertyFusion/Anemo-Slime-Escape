using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    // Singleton instance
    private static AudioManagerScript instance;

    private void Awake() {
        // Check if there is already an instance of AudioManagerScript
        if (instance == null) {
            // If not, set this instance and mark it as not to be destroyed
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            // If an instance already exists, destroy the new one to avoid duplicates
            Destroy(gameObject);
        }
    }

    private void Start() {
        // Check if the music is already playing to avoid restarting it
        if (!musicSource.isPlaying) {
            musicSource.Play();
        }
    }
}
