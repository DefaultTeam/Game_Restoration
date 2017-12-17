﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [Header("Speeds")]
    public float WalkSpeed = 3;
    public float JumpForce = 10;

    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _walkTime = 0, _walkCooldown = 0.2f;
    private float _jumpTime = 0, _jumpCooldown = 1.4f;
    public bool isStels = false;
    public bool underTruba = false;

    private float startX, startY;
 
    private void AnimMove()
    {
        if (!isStels)
        {
            _animatorController.Play("Walk");
            _collider.offset = new Vector3(0, 0);
            _collider.size = new Vector3(2, 7);

        }
        else
        {
            _animatorController.Play("Stels");
            _collider.offset = new Vector3(0, -1.5f);
            _collider.size = new Vector3(2, 3.8f);
        }
    }

    public void MoveRight()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                Debug.Log("hello");
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Right;
            }
            _walkTime = _walkCooldown;
            AnimMove();
        }
    }

    public void MoveLeft()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Right)
            {
                Debug.Log("hello");
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Left;
            }
            _walkTime = _walkCooldown;
            AnimMove();
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            //_rigidbody.velocity = (Vector3.up * JumpForce * Time.deltaTime);
            _rigidbody.AddForce(new Vector2(0, JumpForce));
            _moveState = MoveState.Jump;
            _animatorController.Play("Jump");
            _jumpTime = _jumpCooldown;
        }
    }


    private void Idle()
    {
        _moveState = MoveState.Idle;
        _animatorController.Play("Idle");
    }

    private void Dead()
    {
        transform.position = new Vector3(startX, startY, transform.position.z);
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animatorController = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
        startX = transform.position.x;
        startY = transform.position.y;

    }

    private void Update()
    {
        switch (_moveState)
        {
            case MoveState.Jump:
                {
                    _jumpTime -= Time.deltaTime;
                    if (_jumpTime <= 0)
                    {
                        Idle();
                    }
                    //if (_rigidbody.velocity == Vector2.zero)
                    //{
                    //   Idle();
                    //}
                }
                break;
            case MoveState.Walk:
                {
                    Vector3 direction = (_directionState == DirectionState.Right ? 1 : -1) * _transform.right;
                    _transform.position = (Vector3.MoveTowards(_transform.position, _transform.position + direction, WalkSpeed * Time.deltaTime));
                    //_rigidbody.velocity = ((_directionState == DirectionState.Right ? Vector2.right : -Vector2.right) * WalkSpeed * Time.deltaTime);
                    _walkTime -= Time.deltaTime;
                    if (_walkTime <= 0)
                    {
                        Idle();
                    }
                }
                break;
            case MoveState.Stels:
                {
                    Vector3 direction = (_directionState == DirectionState.Right ? 1 : -1) * _transform.right;
                    _transform.position = (Vector3.MoveTowards(_transform.position, _transform.position + direction, WalkSpeed * Time.deltaTime));
                    //_rigidbody.velocity = ((_directionState == DirectionState.Right ? Vector2.right : -Vector2.right) * WalkSpeed * Time.deltaTime);
                
                    _walkTime -= Time.deltaTime;
                    if (_walkTime <= 0)
                    {
                        isStels = false;
                        Idle();
                    }
                }
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EdgeCollider2D>().tag == "puddle")
        {
            Dead();
        }
    }

    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        Walk,
        Jump,
        Stels
    }
}