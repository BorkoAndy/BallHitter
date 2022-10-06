using System;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField] private float _hitForce;
    private Rigidbody _rb;
   
    public static event Action ActivateCue;

    private void Awake() => _rb = GetComponent<Rigidbody>();       
    
    private void Update()
    {
        if (_rb.velocity == Vector3.zero) 
            ActivateCue();        
    }
    public void BallHit(Vector3 direction) => _rb.AddForce(-direction * _hitForce, ForceMode.Impulse);       
}
