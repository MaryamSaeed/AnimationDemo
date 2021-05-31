using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// struct to hold the selected sphere description across scenes
/// </summary>
public struct SphereDesciptor 
{
    public Vector3 SphereScale;
    public Material SphereMaterial;
    public PrimitiveType SphereAdditions;
}
/// <summary>
/// class that act as temp location when switching between scenes
/// </summary>
public static class SphereDesciptorLocator
{
    public static SphereDesciptor SelectedSphereDescriptor;
}
