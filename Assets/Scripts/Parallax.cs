using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public static Transform viewer;

    public Vector2 originPosition;
    public Vector2 parallaxSpeed;

    private void Awake()
    {
        originPosition = this.transform.position;
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (viewer == null || viewer.position.z >= 0.0f)
            return;

        Vector2 u = originPosition - (Vector2)viewer.position;
        Vector2 v = originPosition + u * parallaxSpeed;

        transform.position = new Vector3(v.x, v.y, transform.position.z);
    }

    private void Update()
    {
            
    }
}