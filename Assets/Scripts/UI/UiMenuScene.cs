using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiMenuScene : MonoBehaviour
{
    public ColorPicker ColorPicker;

    // Start button
    public void StartGame()
    {
        SceneManager.LoadScene(1);

        PlayerPrefs.DeleteKey("Score");
    }

    // Resume button
    public void ResumingGame()
    {
        SceneManager.LoadScene(1);
    }

    // Exit button
    public void ExitGame()
    {
 #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NewColorSelected(Color color)
    {
        ColorManager.Instance.BallColor = color;
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectColor(ColorManager.Instance.BallColor);
    }

    public void SaveColorClicked()
    {
        ColorManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        ColorManager.Instance.LoadColor();
        ColorPicker.SelectColor(ColorManager.Instance.BallColor);
    }
}

