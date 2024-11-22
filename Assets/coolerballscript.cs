using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolerballscript : MonoBehaviour
{
    private bool IsPressed;

    private float releaseDelay;

    private float maxDragDistance = 4f;

    private Rigidbody2D slingRb;

    private Rigidbody2D rb;
    
    private SpringJoint2D sj;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingRb = sj.connectedBody;

        releaseDelay = 1 / (sj.frequency * 4);
    }
    void Update()
    {
        if (IsPressed)
        {
            DragBall();
        }
    }
    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingRb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        } else
        {
            rb.position = mousePosition;
        }

        
    }
    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }


    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        
    }
}