using System.Collections;
using UnityEngine;
using TMPro;


public class GUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text hitCounterText;
 
    private int hitsCounter;
    private int timer;
    private void OnEnable()
    {
        Cue.OnHit += HitCounterUpdate;
        EndGame.OnGameOver += StopAllCoroutines;
    }
    private void OnDisable()
    {
        Cue.OnHit -= HitCounterUpdate;
        EndGame.OnGameOver -= StopAllCoroutines;
    }
    private void Start() => StartCoroutine(TimerUpdate());
    
    private void Update()
    {        
        float minutes = (timer / 60);
        float seconds = (timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);        
        hitCounterText.text = hitsCounter.ToString();
    }
    private void HitCounterUpdate() => hitsCounter++;    
    private IEnumerator TimerUpdate()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(1f);
            timer++;
        }
    }
}
