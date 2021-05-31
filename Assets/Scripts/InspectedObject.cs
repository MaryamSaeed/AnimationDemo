using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class the reconstruct the Inpected object selected from previous scene
/// </summary>
public class InspectedObject : MonoBehaviour
{
    [Tooltip("Desired position of the addition object")]
    public Vector3 AdditionsPosition = new Vector3(-1, 0, -6);
    private SphereDesciptor desiredSphere;
    private AnimationsHelpers animationsHelpers;
    // Start is called before the first frame update
    void Start()
    {
        desiredSphere = SphereDesciptorLocator.SelectedSphereDescriptor;
        transform.localScale = desiredSphere.SphereScale;
        GetComponent<MeshRenderer>().material = desiredSphere.SphereMaterial;
        animationsHelpers = FindObjectOfType<AnimationsHelpers>();
        AdditionalObjectGeneration();
    }
    /// <summary>
    /// generated the primative object mentioned in the descriptor
    /// </summary>
    private void AdditionalObjectGeneration()
    {
        var additionObject = GameObject.CreatePrimitive(desiredSphere.SphereAdditions);
        additionObject.transform.localScale = transform.localScale;
        additionObject.transform.localPosition = AdditionsPosition;
        additionObject.transform.parent = transform;
        var rendrer = additionObject.GetComponent<MeshRenderer>();
        rendrer.material = desiredSphere.SphereMaterial;
        rendrer.material.color = new Color(1, 0, 0, 0);
        animationsHelpers.FadeInObject(rendrer);
    }
}
