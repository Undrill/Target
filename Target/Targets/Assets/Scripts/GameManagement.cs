using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

    public GameObject RetryButton;
    public TargetBehavior Target;
    public PlayerBehavior Player;

    private int Score;

    private void Start()
    {
        RetryButton.SetActive(false);
        Score = 0;
        
    }

    public void OnRetryPress()
    {
        Debug.Log("Retry Pressed");
        SceneManager.LoadScene(0);
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player is Dead");
        Debug.Log("Score is: " + Score);
        RetryButton.SetActive(true);
    }

    public void OnTargetHit()
    {
        Debug.Log("Target Hit function called");
        Score = Score + 1;
        Player.LevelUp();
        Target.LevelUp();
    }
}
