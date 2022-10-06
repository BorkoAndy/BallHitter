using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public static event Action OnPlayerDestroy, OnBallFallHole;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerBall")) OnPlayerDestroy?.Invoke();            
        
        Destroy(other.gameObject);
        OnBallFallHole?.Invoke();
    }        
}
