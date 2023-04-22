using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol3 : MonoBehaviour
{
    public GameObject PointE;
    public GameObject PointF;
    private Rigidbody2D rb;
    private Animator Enemy;
    private Transform currentPoint;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy = GetComponent<Animator>();
        currentPoint = PointF.transform;
        Enemy.SetBool("isRunning", true);
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointF.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointF.transform)
        {
            flip();
            currentPoint = PointE.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointE.transform)
        {
            flip();
            currentPoint = PointF.transform;
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
        Gizmos.DrawWireSphere(PointE.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointF.transform.position, 0.5f);
        Gizmos.DrawLine(PointE.transform.position, PointF.transform.position);
    }
}
