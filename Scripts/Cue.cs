using System;
using UnityEngine;

public class Cue : MonoBehaviour
{   
    private bool _readyForHit;
   
    public static event Action OnHit;

    public PlayerBall playerBall;
    public GameObject cueSprite;        

    private void OnEnable() => PlayerBall.ActivateCue += SetActive;    

    private void OnDisable() => PlayerBall.ActivateCue -= SetActive;
   
    private void SetActive()
    {        
        cueSprite.SetActive(true);
        transform.position = playerBall.transform.position;
        _readyForHit = true;
    }
    private void SetUnActive()
    {
        cueSprite.SetActive(false);
        _readyForHit = false;
        OnHit?.Invoke();
    }

    private void FixedUpdate()
    {
        if (playerBall)
        {
            Vector3 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 hitDirection = pointerPosition - playerBall.transform.position;
            hitDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(hitDirection);

            if (_readyForHit && Input.GetMouseButtonDown(0))
            {
                playerBall.BallHit(hitDirection);
                SetUnActive();
            }
        }
    }
}
