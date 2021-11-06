using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIGameScene : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject turret;
    public TMP_InputField userInputField;
    public TextMeshProUGUI userNameText;
    public GameObject menu;
    public GameObject gameOver;
    public GameObject resetScore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
        {
            userNameText.text = PlayerPrefs.GetString("UserName");
        }
    }

    // In GameScene
    public void BackToMenu()
    {
        PlayerPrefs.SetInt("Score", ScoreManager.Instance.score);
        PlayerPrefs.SetInt("HighScore", ScoreManager.Instance.highScore);
        SceneManager.LoadScene(0);
    }

    // In GameScene GameOverButton
    public void GoToGameOverPanel()
    {
        
        turret.SetActive(false);
        menu.SetActive(false);
        gameOver.SetActive(false);
        resetScore.SetActive(false);

        if (ScoreManager.Instance.highScore > PlayerPrefs.GetInt("HighScore"))
        {
            panel.SetActive(true);
        }
        else
        {
            panel2.SetActive(true);
        }

        PlayerPrefs.SetInt("Score", ScoreManager.Instance.score);
        PlayerPrefs.SetInt("HighScore", ScoreManager.Instance.highScore);
    }

    // In GameScene and Panel - Exit Button
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
   Application.Quit(); // original code to quit Unity player
#endif
    }

    // In GameScene Reset High Score Button
    public void ResetHS()
    {
        ScoreManager.Instance.ResetHighScore();
        ResetName();
    }

    public void ResetName()
    {
       userNameText.text = "";
    }

    // In Panel
    // to submit the Input name
    public void SubmitButton()
    {
        userNameText.text = userInputField.text;
        PlayerPrefs.SetString("UserName", userNameText.text);
        Debug.Log("SetName");
    }

    // In Panel
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
