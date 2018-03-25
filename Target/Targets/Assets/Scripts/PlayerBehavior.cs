using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    private bool launch;

    private Vector2 InitialPlayerPosition;

    private int Score = 0;
    public float PlayerSpeed = 0.8f;

    public GameObject RetryButton;

    void Start()
    {
        InitialPlayerPosition = this.transform.position;
        RetryButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            launch = true;
        }

        if (launch)
        {
            LaunchPlayer();
        }
    }

    void LaunchPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(0, 5000), PlayerSpeed);

        if (this.transform.position.y > Camera.main.orthographicSize)
        {
            Debug.Log("Player is out of screen");
            OnPlayerDeath();
        }
    }

    void OnPlayerDeath()
    {
        launch = false;
        this.gameObject.SetActive(false);
        RetryButton.SetActive(true);
    }

    void LevelUp()
    {
        launch = false;
        this.transform.position = InitialPlayerPosition;
        Score = Score + 1;
        GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<Text>().text = Score.ToString();
    }

    public void OnRetryPressed()
    {
        this.transform.position = InitialPlayerPosition;
        this.gameObject.SetActive(true);
        RetryButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player hit an enemy");
            OnPlayerDeath();
        }

        else if (collision.gameObject.tag == "Target")
        {
            Debug.Log("Player hit the target");
            LevelUp();
        }

    }
}
