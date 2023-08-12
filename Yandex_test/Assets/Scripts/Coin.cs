using UnityEngine;

public class Coin : SpawnerAbstarct
{
    [SerializeField] private float _speed;
    [SerializeField] private float _startingDistance;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (CheckOnDistance())
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }  
    }

    private bool CheckOnDistance()
    {
        return Vector3.Distance(transform.position, _player.transform.position) <= _startingDistance;
    }
}
