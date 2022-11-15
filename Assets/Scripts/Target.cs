using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Vector2 a = transform.position;
        Vector2 b = target.position;
        transform.position = Vector2.MoveTowards(a, b, speed);

    }
}
