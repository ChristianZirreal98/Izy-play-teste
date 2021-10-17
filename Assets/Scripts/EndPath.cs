using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPath : MonoBehaviour
{
    [SerializeField] List<GameObject> parts;
    private void Start()
    {
        int r = Random.Range(0, parts.Count);

        parts[r].gameObject.SetActive(true);
    }
}
