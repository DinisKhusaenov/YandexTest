using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerAbstarct _prefab;
    [SerializeField] private float _spawnFrequency;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private Player _player;

    private readonly float _distanceBetweenEnemy = 1.5f;
    private float _timer;
    private bool _isIncrease = false;

    private void Update()
    {
        PrefabSpawn();
    }

    private void PrefabSpawn()
    {
        if (_timer >= _spawnFrequency)
        {
            _timer = 0;
            if (_prefab is Enemy)
            {
                var enemy = (Enemy) _prefab;
                PrefabInstantiate(_spawnDistance, enemy.gameObject);
                PrefabInstantiate(_spawnDistance + _distanceBetweenEnemy, enemy.gameObject);
                Increase(enemy);
            }
            else if (_prefab is Coin)
            {
                var coin = (Coin) _prefab;
                PrefabInstantiate(_spawnDistance - 1.5f, coin.gameObject);
            }
        }

        _timer += Time.deltaTime;
    }

    private void PrefabInstantiate(float distance, GameObject prefab)
    {
        var randomY = Random.Range(-3f, 3f);
        var newEnemy = Instantiate(prefab);

        newEnemy.transform.position = new Vector3(_player.transform.position.x + distance, randomY, 0);

        Destroy(newEnemy, 7f);
    }

    private void Increase(Enemy enemy)
    {
        if (Score.score >= 6 && !_isIncrease)
        {
            _isIncrease = true;
            PrefabInstantiate(_spawnDistance + 2 * _distanceBetweenEnemy, enemy.gameObject);
        }
    }
}
