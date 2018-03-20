using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {

    private bool alive;
    private float speed;
    private PolygonCollider2D ObjectCollider;
    private Vector2 ColliderSize;
    private Vector2 ScreenBoundsX;
    private Camera cam;
    private float CameraWidth;

    void Start ()
    {
        cam = Camera.main;
        alive = true;
        speed = Random.Range(0.01f, 0.001f);
        ObjectCollider = GetComponent<PolygonCollider2D>();
        ColliderSize = ObjectCollider.bounds.size;
        CameraWidth = cam.orthographicSize * cam.aspect;
        Debug.Log("Camera Width : " + CameraWidth);
        ScreenBoundsX = new Vector2(CameraWidth - ColliderSize.x /2, this.transform.position.y);
        Debug.Log("Screen Bound X : " + ScreenBoundsX);
	}
   
    void Update ()
    {
	if (alive)
        {

            if (Vector2.Distance(this.transform.position, ScreenBoundsX) > 0.0f)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, ScreenBoundsX, speed);
            }
           else
            {
                ScreenBoundsX.x = ScreenBoundsX.x * -1;
                Debug.Log("ElseCondition ScreenBoundX");
            }
            
            if (ScreenBoundsX.x > this.transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
        }	
	}

   /* ------------------------------------------------------
    *private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.name + "has been hit");
        if (collision.gameObject.tag = "Knife")
        {
            Death();
        }
    }
 ------------------------------------------------------ */

    /* ---------------------------------------------
     * *COMMENT* Death Function
     * public void Death()
     * {
        // *COMMENT* Instantiate a death particle on current enemy position
        // Instantiate(deathparticle, this.transform.position, Quaternion.identity);
        alive = false;
        this.GetComponent<AudioSource>().PlayOneShot(failed);
        Initiate.Fade("Main", Color.white, 2.0f);
    }
    ------------------------------------------------- */
}
