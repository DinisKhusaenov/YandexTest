using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;

    public static int score;

    private void Start()
    {
        score = 0;
        ChangeText();
    }

    private void OnEnable()
    {
        _player.OnScoreChanged += ChangeText;
    }

    private void OnDisable()
    {
        _player.OnScoreChanged -= ChangeText;
    }

    private void ChangeText()
    {
        _scoreText.text = score.ToString();
    }
}
