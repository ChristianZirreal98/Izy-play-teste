using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Path", menuName ="ScriptableObjects/ New Path")]
public class Path : ScriptableObject
{
    [SerializeField] List<Part> parts;

    public List<Part> Get_parts { get { return parts; } }
}
