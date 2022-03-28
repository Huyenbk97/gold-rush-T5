using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lence : MonoBehaviour
{
    public static Lence instance;

    public Mesh sphereMash;
    public Mesh orgMesh;
    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("First"))
        {
            other.gameObject.tag = "Second";
            other.gameObject.GetComponent<MeshFilter>().mesh = sphereMash;
            other.gameObject.GetComponent<MeshRenderer>().material.color = GameObject.Find("Player").GetComponent<MeshRenderer>().material.color;
        }
    }
}
