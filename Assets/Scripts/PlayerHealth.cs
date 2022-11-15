using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    [Header("Health")]
    public int life = 2;
    public GameObject menuGameOver;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamege(1);
        }
    }
    public void TakeDamege(int damage)
    {
        life -= damage;
        if (life == 1)
        {
            Enemy.Instance.enemyClose = true;
        }
        if(life <= 0)
        {
            Enemy.Instance.playerDead = true;
            Enemy.Instance.enemyClose = false;
            menuGameOver.SetActive(true);
        }
    }


}
