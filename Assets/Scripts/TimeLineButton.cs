using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// timeline buttons allows the user to navigat to a desired screen
/// </summary>
public class TimeLineButton : MonoBehaviour
{
    [Tooltip("Button ID consistant with the scene it navigates to ")]
    public int ButtonID;
    private Button timelineButton;

    // Start is called before the first frame update
    void Start()
    {
        timelineButton = GetComponent<Button>();
        if (ButtonID >= 0)
        {
            timelineButton.GetComponentInChildren<Text>().text = ButtonID.ToString();
            timelineButton.onClick.AddListener(OnCLick);
            if (ButtonID == PlayerPrefs.GetInt(Constants.CurrentScene))
                timelineButton.interactable = false;
        }
        else
            Debug.Log("please Assign a button ID");
    }
    private void OnCLick()
    {
        var targetScene = GetSceneName(ButtonID);
        if (!string.IsNullOrEmpty(targetScene))
        {
            PlayerPrefs.SetInt(Constants.CurrentScene, ButtonID);
            Debug.Log(PlayerPrefs.GetInt(Constants.CurrentScene).ToString());
            SceneManager.LoadScene(targetScene);
        }
    }
    /// <summary>
    /// maps the button ID to the desired scene
    /// </summary>
    /// <param name="id">button id</param>
    /// <returns>scene name </returns>
    private string GetSceneName(int id)
    {
        switch (id)
        {
            case 1:
                return Constants.Scene1;
            case 2:
                return Constants.Scene2;
            case 3:
                return Constants.Scene3;
        }
        return string.Empty;
    }
}
