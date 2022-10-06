using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject Balls;
    [SerializeField] private GameObject playerWinsScreen;
    [SerializeField] private GameObject gameOverScreen;

    public static event Action OnGameOver;

    public int ballsLeft;

    private void OnEnable() => Hole.OnPlayerDestroy += PlayerDestroyed;
    private void OnDisable() => Hole.OnPlayerDestroy -= PlayerDestroyed;
    private void LateUpdate() => BallsLeft();
        
    private void BallsLeft()
    {
        ballsLeft = Balls.transform.childCount;
        if (ballsLeft <= 0) PlayerWins();
    }
    private void PlayerWins()
    {
        OnGameOver?.Invoke();        
        playerWinsScreen.SetActive(true);
    }
    private void PlayerDestroyed()
    {
        OnGameOver?.Invoke();
        gameOverScreen.SetActive(true);        
    }
}
