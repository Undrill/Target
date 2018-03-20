using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    public GameObject RetryButton;

    private void Start()
    {
        RetryButton.SetActive(false);
        
    }

    public void OnRetryPress()
    {
        Debug.Log("Retry Pressed");
        SceneManager.LoadScene(0);
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player Death function called");
        RetryButton.SetActive(true);
    }
}
