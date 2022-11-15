using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 30;
    [Header("Ground")]
    public LayerMask _groundLayer;
    private bool _isGround;
    public Transform _groundController;
    public Vector3 _dimensionBox;
    [Header("Jump")]
    public float jumpForce;
    public float jumpMove;
    public bool _isJump = false;
    [Header("Crouch")]
    public float crouchForce;
    public bool _isCrouch = false;
    [Header("Dash")]
    public float dashingPower = -24f;
    private bool _canDash = true;
    public bool _isDashing;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        if(SwipeManager.Instance.SwipeUp && _isGround)
        {
            Jump();
        }
        if (SwipeManager.Instance.SwipeDown && _isGround)
        {
            
            Crouch();
        }
        if(SwipeManager.Instance.SwipeLeft && _isGround)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        _isGround = Physics2D.OverlapBox(_groundController.position, _dimensionBox, 0f, _groundLayer);

         _isJump = false;

       
        _isCrouch = false;

        if (_isDashing)
        {
            return;
        }
    }

    private void Crouch()
    {
        if (_isCrouch)
        {
            return;
        }
        _rb.AddForce(new Vector2(crouchForce, 0f));
        _isCrouch = true;
    }

    private void Jump()
    {

        _rb.AddForce(new Vector2(jumpMove, jumpForce));
        _isJump = true;
        _isGround = false;

    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        _canDash = true;
    }

    
    


}