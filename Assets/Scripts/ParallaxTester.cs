using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTester : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    private float m_dx;
    private float m_dy;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float sx = m_dx * moveSpeed * Time.fixedDeltaTime;
        float sy = m_dy * moveSpeed * Time.fixedDeltaTime;

        transform.position += new Vector3(sx, sy, 0.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Parallax.viewer = this.transform;

        m_dx = Input.GetAxisRaw("Horizontal");
        m_dy = Input.GetAxisRaw("Vertical");
    }
}
