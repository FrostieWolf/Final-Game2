using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
{
    public GameObject PointC;
    public GameObject PointD;
    private Rigidbody2D rb;
    private Animator Enemy;
    private Transform currentPoint;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy = GetComponent<Animator>();
        currentPoint = PointD.transform;
        Enemy.SetBool("isRunning", true);
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointD.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointD.transform)
        {
            flip();
            currentPoint = PointC.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointC.transform)
        {
            flip();
            currentPoint = PointD.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointD.transform.position, 0.5f);
        Gizmos.DrawLine(PointC.transform.position, PointD.transform.position);
    }
}