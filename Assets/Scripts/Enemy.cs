using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    public bool enemyClose = false;
    public bool playerDead = false;
    private Rigidbody2D _rb;
    public Transform targetEnemy1;
    public Transform targetEnemy2;
    public float speed = 0.1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 a = transform.position;
        Vector2 tar1 = targetEnemy1.position;
        Vector2 tar2 = targetEnemy2.position;

        if (enemyClose)
        {
            transform.position = Vector2.MoveTowards(a, tar1, speed);
        }
        if (playerDead)
        {
            transform.position = Vector2.MoveTowards(a, tar2, speed);
            //Animacion de muerte
        }
    }
}
