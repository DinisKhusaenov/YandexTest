using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    public Action OnScoreChanged;
    public Action OnSpacePressed;

    private bool _isSpacePressed = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
            if (!_isSpacePressed)
            {
                _isSpacePressed = true;
                OnSpacePressed?.Invoke();
            }
        }
    }

    private void Move()
    {
        transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" || collision.TryGetComponent(out Enemy enemy))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.TryGetComponent(out Coin coin))
        {
            Score.score++;
            Destroy(collision.gameObject);
            OnScoreChanged?.Invoke();
        }
    }
}
