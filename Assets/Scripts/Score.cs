using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Transform player;
    public float speed = 0.001f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(new Vector2(speed, 0f));
        score.text = player.position.x.ToString("0");
        if(PlayerHealth.Instance.life == 0)
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
