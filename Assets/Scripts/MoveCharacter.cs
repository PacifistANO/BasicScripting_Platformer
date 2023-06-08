using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        Debug.Log("Move - A,D | LeftArrow, RightArrow \nJump - Space | Jump only if you stay on ground");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetTrigger(CharacterAnimatorController.Triggers.RunTrigger);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.ResetTrigger(CharacterAnimatorController.Triggers.RunTrigger);
            _animator.SetTrigger(CharacterAnimatorController.Triggers.IdleTrigger);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetTrigger(CharacterAnimatorController.Triggers.RunTrigger);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.ResetTrigger(CharacterAnimatorController.Triggers.RunTrigger);
            _animator.SetTrigger(CharacterAnimatorController.Triggers.IdleTrigger);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_rigidbody2D.velocity.y == 0)
            {
                _animator.SetTrigger(CharacterAnimatorController.Triggers.JumpTrigger);
                _rigidbody2D.AddForce(_jumpForce * Vector2.up);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<MoveEnemy>(out MoveEnemy moveEnemy))
        {
            transform.position = new Vector3(6.7f, 1.94f);
        }
    }
}
