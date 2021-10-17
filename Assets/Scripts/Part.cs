using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part" , menuName ="ScriptableObjects/New Part")]
public class Part : ScriptableObject
{
    [SerializeField] GameObject obj;
    [SerializeField] Transform spawn_next_obj;
    [SerializeField] Vector3 offset_objc;
    [SerializeField] bool is_long_obj;

    public GameObject Get_obj { get { return obj; } }
    public Transform Get_spawn_next_obj { get { return spawn_next_obj; } }
    public Vector3 Get_offset_obj { get { return offset_objc; } }
    public bool Get_is_long_obj { get { return is_long_obj; } }
    
}
