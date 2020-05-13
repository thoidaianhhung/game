using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton, resumeButton, restartButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText, panelText;

    [SerializeField]
    private GameObject gameOverPanel, brozenMedal, goldMedal, whiteMedal, blue, green, red;

    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Change bird inside play game
    private void Start()
    {
        if (GameManager.instance.GetSelectedBird() == 0)
        {
            blue.SetActive(true);
            green.SetActive(false);
            red.SetActive(false);
            Debug.Log("Selected " + GameManager.instance.GetSelectedBird());
        }
        else if (GameManager.instance.GetSelectedBird() == 1)
        {
            blue.SetActive(false);
            green.SetActive(true);
            red.SetActive(false);
            Debug.Log("Selected " + GameManager.instance.GetSelectedBird());
        }
        else if (GameManager.instance.GetSelectedBird() == 2)
        {
            blue.SetActive(false);
            green.SetActive(false);
            red.SetActive(true);
            Debug.Log("Selected " + GameManager.instance.GetSelectedBird());
        }

    }

    // Process when user clicks InstructionButton
    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    //  Show score and assign a new score to the score
    public void SetScore(int newscore)
    {
        scoreText.text = "" + newscore; 
        score = newscore;
    }

    // Show when the bird is dead
    public void BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        panelText.text = "GAME OVER";
        Debug.Log("BirdDiedShowPanel: " + score);

        if (score > GameManager.instance.GetHighscore())
        {
            GameManager.instance.SetHighscore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighscore();
        SwitchMedal(score);
        restartButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    // When the user presses MenuButton
    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.SetSelectedBird(0);
    }

    // When the user presses RestartButton
    public void RestartButton() {
        SceneManager.LoadScene("GamePlay");
    }

    int score;

    // Displayed when pressing Pause
    public void PauseButton()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        panelText.text = "PAUSE";
        endScoreText.text = "" + score;
        if(score > GameManager.instance.GetHighscore())
        {
            GameManager.instance.SetHighscore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighscore();
        Debug.Log("score pasue " + score);
        SwitchMedal(score);
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    // Medal changes
    public void SwitchMedal(int score)
    {
        if (score <= 20)
        {
            goldMedal.SetActive(false);
            whiteMedal.SetActive(true);
            brozenMedal.SetActive(false);
            Debug.Log("score " + score);
        }
        else if (score > 20 && score < 40)
        {
            goldMedal.SetActive(false);
            whiteMedal.SetActive(false);
            brozenMedal.SetActive(true);
            Debug.Log("score " + score);
        }
        else if (score >= 40)
        {
            goldMedal.SetActive(true);
            whiteMedal.SetActive(false);
            brozenMedal.SetActive(false);
            Debug.Log("score " + score);
        }
        
    }
}
