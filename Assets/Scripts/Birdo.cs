using System;
using System.Collections;
using UnityEngine;

public class Birdo : MonoBehaviour
{
    public float _jumpForce;

    Rigidbody2D _rb;

    public int _lives = 3;

    public float _dashCooldown;
    public float _currentCooldown;
    public  bool _dead;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            //
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //_lives--;


                if (_currentCooldown >= _dashCooldown)
                {
                    StartCoroutine("Dash");
                }
            }

            if (_currentCooldown < _dashCooldown)
            {
                _currentCooldown += 1f * Time.deltaTime;
            }
        }
    }

    IEnumerator Dash()
    {
        _rb.velocity = Vector2.zero;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _currentCooldown = 0;

        yield return new WaitForSeconds(.3f);


        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            HitPipe();
        }

        if (collision.gameObject.tag == "Ground")
        {
            Die();
        }
    }

    private void HitPipe()
    {
        if (_lives == 0)
        {
            Die();
        }

        GameManager.instance.ClearScreen();
    }

    private void Die()
    {
        //Do something i dunno
        _lives = 0;
        _dead = true;
    }
}
