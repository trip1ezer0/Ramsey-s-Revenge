using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public GameObject child;

    public float smoothSpeed = 3f;
    public Vector2 offset;
    private Vector2 threshold;
    private Rigidbody2D rb;

    private void Start()
    {
        threshold = calculateThreshold();
        rb = target.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        Vector2 follow = child.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if (Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        float moveSpeed = rb.velocity.magnitude > smoothSpeed ? rb.velocity.magnitude : smoothSpeed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= offset.x;
        t.y -= offset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
