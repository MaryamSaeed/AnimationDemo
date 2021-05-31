using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class resposible for controlling the camera movements & zooming
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("focused object")]
    public GameObject TargetObject;
    [Tooltip("the speed of camera movement")]
    public float rotationspeed;
    [Tooltip(" Maximum allowable zoom")]
    public float Maxzoom = 100;
    [Tooltip(" Minimun allowable zoom")]
    public float Minzoom = 20;
    [Tooltip("factor of swipe speed")]
    public float SwipeSpeed;
    [Tooltip(" minimum swipe value ")]
    public float SwipeThreshold;
    private void Start()
    {
        transform.LookAt(TargetObject.transform);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            RotateContent();
        ZoomHandler();
    }
    /// <summary>
    /// rotates the content according to mouse move 
    //along the axis
    /// </summary>
    private void RotateContent()
    {
        var rotationAngle = Input.GetAxis("Mouse X") * rotationspeed * Time.deltaTime;
        TargetObject.transform.Rotate(TargetObject.transform.up, -rotationAngle);
    }
    /// <summary>
    /// handles zoom via mouse wheel
    /// </summary>
    private void ZoomHandler()
    {
        float Scrlwhel = Input.GetAxis("Mouse ScrollWheel");
        if (Scrlwhel != 0)
        {
            float zoomvalue = Camera.main.fieldOfView - (Scrlwhel * 4);
            Camera.main.fieldOfView = Mathf.Clamp(zoomvalue, Minzoom, Maxzoom);
        }
    }
}
