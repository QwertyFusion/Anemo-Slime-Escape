using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioSource buttonClick;
    [SerializeField] private GameObject settingsScreen;

    public void startGame() {
        buttonClick.Play();
        PlayerPrefs.SetInt("ShowTutorial", 1);
        SceneManager.LoadScene("Game Level");
    }

    public void settingsButton() {
        buttonClick.Play();
        settingsScreen.SetActive(true);
    }

    public void backSettingsButton() {
        buttonClick.Play();
        settingsScreen.SetActive(false);
    }

    public void exitGame() {
        buttonClick.Play();
        Application.Quit();
    }

    public void resetHighScore() {
        buttonClick.Play();
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
