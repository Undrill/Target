using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private bool launch = false;
    public bool alive = true;

    private Vector2 targetposition;
    public GameManagement GameManagement;

    private int outofscreen = 500000;
    public float playerspeed = 0.3f;

   void Update()
    {
   // Si le joueur tape l'écran, le player est lancé
   if (Input.GetMouseButtonDown(0))
        {
            launch = true;
        }

   if (launch)
        {
            LaunchPlayer();
        }

    }

    // Fonction de lancement & sortie d'écran du joueur
    void LaunchPlayer()
    {
        // Lancement du player tout droit en Y
            targetposition = this.transform.position;
            targetposition.y = targetposition.y + outofscreen;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetposition, playerspeed);

        // Verification de sortie d'écran du player
        if (this.transform.position.y > Camera.main.orthographicSize)
        {
            Debug.Log("Player is out of screen");
            alive = false;
            GameManagement.OnPlayerDeath();
            // A rajouter : Lancer le Game Over Screen
        }
    }

    //Fonction de check des collisions avec les obstacles & la cible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            Debug.Log("Enemy Hit");
            GameManagement.OnPlayerDeath();
            alive = false;
            // A rajouter : Animation destruction Player
            // A rajouter : Lancer le Game Over Screen
        }

        else if (collision.gameObject.tag == "Target")
        {
            this.gameObject.SetActive(false);
            Debug.Log("Target hit");
            // A rajouter : Lancer le prochain "niveau"
        }
    }
}
