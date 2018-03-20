using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector2 HorizontalBounds;
    private Vector2 objectsize;
    private float speed;

    public float minSpeed = 0.02f;
    public float maxSpeed = 0.05f;

    public bool alive = true;

    private Collider2D objectCollider;

    void Start()
    {
        // Check de la taille de l'objet et des limites horizontales du monde
        objectCollider = this.GetComponent<Collider2D>();
        objectsize = objectCollider.bounds.size;
        HorizontalBounds.y = this.transform.position.y;
        HorizontalBounds.x = ((Camera.main.orthographicSize * Camera.main.aspect) - objectsize.x /2);

        // Vitesse des ennemis (parametrables en public)
        speed = Random.Range(minSpeed, maxSpeed);
}


    void Update()
    {
        
        if (Vector2.Distance(this.transform.position,HorizontalBounds) > 0.0f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, HorizontalBounds, speed);
        }
        else
        {
            HorizontalBounds.x = HorizontalBounds.x * -1;
        }

        if (HorizontalBounds.x > this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            alive = false;
            // A rajouter : Animation destruction Enemy
        }
    }
}

