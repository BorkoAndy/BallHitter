using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        Cue.OnHit += OnCueHitBall;
        Hole.OnPlayerDestroy += OnBallFallHole;
        Ball.OnBallHitBall += OnBallHitBall;
        Ball.OnBallHitWall += OnBallHitWall;
        Hole.OnBallFallHole += OnBallFallHole;
    }        
    private void OnDisable()
    {
        Cue.OnHit -= OnCueHitBall;
        Hole.OnPlayerDestroy -= OnBallFallHole;
        Ball.OnBallHitBall -= OnBallHitBall;
        Ball.OnBallHitWall -= OnBallHitWall;
        Hole.OnBallFallHole -= OnBallFallHole;
    }
    private void OnCueHitBall() => audioSource.PlayOneShot(audioClips[3]);
    private void OnBallHitBall() => audioSource.PlayOneShot(audioClips[0]);   
    private void OnBallFallHole() => audioSource.PlayOneShot(audioClips[1]);
    private void OnBallHitWall() => audioSource.PlayOneShot(audioClips[2]);
}
