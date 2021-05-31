using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(OrbitRotation))]
public class InteractableObject : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("the primative type corresponding to the sphere")]
    public PrimitiveType AdditionalObject;
    private SphereDesciptor thisSphereDescriptor;
    private bool selected = false;
    private NotificationCenter notificationCenter;
    // Start is called before the first frame update
    void Start()
    {
        thisSphereDescriptor.SphereScale = transform.lossyScale;
        thisSphereDescriptor.SphereMaterial = GetComponent<MeshRenderer>().material;
        thisSphereDescriptor.SphereAdditions = AdditionalObject;
        notificationCenter = FindObjectOfType<NotificationCenter>();
        notificationCenter.SphereSelected.AddListener(OnSphereSelected);
    }
    /// <summary>
    /// notifys the other objects about the selection 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        selected = true;
        notificationCenter.NotifyOnsphereSelection();
    }
    /// <summary>
    /// carryout the selection and deselection actions
    /// </summary>
    private void OnSphereSelected()
    {
        GetComponent<OrbitRotation>().RotatingObject = false;
        var animationHelpers = FindObjectOfType<AnimationsHelpers>();
        if (selected)
        {
            var targetPosition = new Vector3(0, 0, -6f);
            SphereDesciptorLocator.SelectedSphereDescriptor = thisSphereDescriptor;
            animationHelpers.TransitionEnded.AddListener(OnTransitionEnded);
            animationHelpers.MoveObjectToposition(gameObject, targetPosition);
            selected = false;
        }
        else 
        {
            var rendrer = gameObject.GetComponent<MeshRenderer>();
            animationHelpers.FadeoutObject(rendrer);
        }
    }
    private void OnTransitionEnded()
    {
        PlayerPrefs.SetInt(Constants.CurrentScene, 3);
        SceneManager.LoadScene(Constants.Scene3);
    }
}