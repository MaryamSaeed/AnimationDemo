using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// this class holds the  splash screen's required logic 
/// to be refrenced by the played animation
/// </summary>
public class SplashScreen : MonoBehaviour
{
    public  UnityEvent OnAnimationEnded;
    private void Start()
    {

    }
    /// <summary>
    /// refrenced by an animation event
    /// shows the timelinebuttons when animation ends
    /// </summary>
    public void AnimationEnded()
    {
        OnAnimationEnded.Invoke();
        PlayerPrefs.SetInt(Constants.CurrentScene, 2);
        SceneManager.LoadScene(Constants.Scene2);
    }
}
