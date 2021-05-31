using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// class that restarts the whole experiance
/// </summary>
public class RestartExperience : MonoBehaviour
{
    private Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(OnCLick);
    }
    /// <summary>
    /// loads the first scene in the experience
    /// </summary>
    private void OnCLick()
    {
        PlayerPrefs.SetInt(Constants.CurrentScene, 1);
        SceneManager.LoadScene(Constants.Scene1);
    }
}
