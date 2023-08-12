using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _startText.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _player.OnSpacePressed += StartGame;
    }

    private void OnDisable()
    {
        _player.OnSpacePressed += StartGame;
    }

    private void StartGame()
    {
        _startText.SetActive(false);
        Time.timeScale = 1f;
    }
}
