using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// nitifcation center to handle spheres selection action
/// </summary>
public class NotificationCenter : MonoBehaviour
{
    public UnityEvent SphereSelected;
    /// <summary>
    /// notify all subscribers that a sphere got selected
    /// </summary>
    public void NotifyOnsphereSelection()
    {
        SphereSelected.Invoke();
    }
}
