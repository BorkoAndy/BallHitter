using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static event Action OnBallHitBall, OnBallHitWall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
            OnBallHitBall?.Invoke();
        if (collision.gameObject.CompareTag("wall"))
            OnBallHitWall?.Invoke();
    }
}
