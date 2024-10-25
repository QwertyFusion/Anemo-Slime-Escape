using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;
using UnityEditor;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject scoreTextObj;
    public GameObject gameOverScreen;
    public Text currentScoreValueText;
    public Text highScoreValueText;
    public AudioSource scoreUpSound;
    [SerializeField] private AudioSource buttonClick;

    public void addScore(int scoreToAdd) {
        playerScore+= scoreToAdd;
        scoreUpSound.Play();
        scoreText.text = playerScore.ToString();
    }

    public void resetScore() {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToMainMenu() {
        buttonClick.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void gameOver() {
        scoreTextObj.SetActive(false);
        currentScoreValueText.text = scoreText.text;
        if(int.Parse(currentScoreValueText.text) > int.Parse(highScoreValueText.text)) {
            PlayerPrefs.SetInt("HighScore", int.Parse(currentScoreValueText.text));
        }
        highScoreValueText.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
