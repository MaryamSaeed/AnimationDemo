using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Helper class that contains object animations
/// </summary>
public class AnimationsHelpers : MonoBehaviour
{
    [Tooltip("the value that indecatses how fast the transition animation should be")]
    public float TransitionSpeed = 0.2f;
    [Tooltip("assigns the animation curve used in animating camera move")]
    public AnimationCurve TweeningCurve;
    [Tooltip("the value that indecatses how fast the fadeout animation should be")]
    public float FadeOutSpeed = 2;
    public UnityEvent TransitionEnded;
    /// <summary>
    /// encapsolates the fadeout coroutine
    /// </summary>
    /// <param name="renderer">mesh rendered of the faded object</param>
    public void FadeoutObject(MeshRenderer renderer)
    {
        StartCoroutine(AnimateObjectFadeout(renderer));
    }
    public void FadeInObject(MeshRenderer renderer)
    {
        StartCoroutine(AnimateObjectFadeIn(renderer));
    }
    /// <summary>
    /// encapsulate the transition animation
    /// </summary>
    /// <param name="transitioned">object to be transitioned</param>
    /// <param name="targetposition">the position to be translated to </param>
    public void MoveObjectToposition(GameObject transitioned, Vector3 targetposition)
    {
        StartCoroutine(AnimateObjectTransition(transitioned.transform, targetposition, TweeningCurve));
    }
    /// <summary>
    /// animate any game object's position changes
    /// </summary>
    ///<param name="transitioned">object to be transitioned</param>
    /// <param name="targetpos">target position</param>
    /// <param name="curve">the animation curve</param>
    /// <returns></returns>
    private IEnumerator AnimateObjectTransition(Transform transitioned, Vector3 targetpos, AnimationCurve curve)
    {
        float curvetimer = 0.0f;
        float curveamount = 0.0f;
        var camparent = Camera.main.transform.parent;
        while (curvetimer < 1)
        {
            curveamount = curve.Evaluate(curvetimer);
            transitioned.position = Vector3.Lerp(transitioned.position, targetpos, curveamount);
            curvetimer += Time.deltaTime * TransitionSpeed;
            yield return null;
        }
        TransitionEnded.Invoke();
    }
    /// <summary>
    /// animates the fadeout transition of an object
    /// </summary>
    /// <param name="rendere">objet mesh rendere</param>
    /// <returns></returns>
    private IEnumerator AnimateObjectFadeout(MeshRenderer rendere)
    {
        var objectcolor = rendere.material.color;
        while (objectcolor.a > 0)
        {
            objectcolor.a -= Time.deltaTime * FadeOutSpeed;
            rendere.material.color = objectcolor;
            yield return null;
        }
    }
    /// <summary>
    /// animates the fadeIn transition of an object
    /// </summary>
    /// <param name="rendere">objet mesh rendere</param>
    /// <returns></returns>
    private IEnumerator AnimateObjectFadeIn(MeshRenderer rendere)
    {
        var objectcolor = rendere.material.color;
        while (objectcolor.a < 1)
        {
            objectcolor.a += Time.deltaTime * FadeOutSpeed;
            rendere.material.color = objectcolor;
            yield return null;
        }
    }
}
