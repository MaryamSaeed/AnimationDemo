using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this class rotates an object in a fixed orbit
/// </summary>
public class OrbitRotation : MonoBehaviour
{
    [Tooltip("the forcused object")]
    public Transform CenterOfRotation;
    [Tooltip("radius of orbit")]
    public float radius = 2.0f;
    [Tooltip("object rotation speed")]
    public float rotationSpeed = 80.0f;
    [Tooltip("Object Rotation switch")]
    public bool RotatingObject = true;
    // Start is called before the first frame update
    private void Start()
    {
        if (RotatingObject)
            transform.position = (transform.position - CenterOfRotation.position).normalized * radius + CenterOfRotation.position;
    }
    private void Update()
    {
        if (RotatingObject)
        {
            var rotationAngle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(CenterOfRotation.position, CenterOfRotation.forward, rotationAngle);
            var desiredPosition = (transform.position - CenterOfRotation.position).normalized * radius + CenterOfRotation.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime);
        }
    }
}
