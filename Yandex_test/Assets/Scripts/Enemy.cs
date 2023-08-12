using UnityEngine;

public class Enemy : SpawnerAbstarct
{
    [SerializeField] private float _speed;

    private int _direction = 1;

    private void Start()
    {
        _direction = Random.value < 0.5f ? _direction : -_direction;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, _direction * _speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead")
            _direction *= -1;
    }
}
