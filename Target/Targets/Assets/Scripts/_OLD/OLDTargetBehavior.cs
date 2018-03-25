using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDTargetBehavior : MonoBehaviour {

    private bool shouldMove = false;

    private Vector2 HorizontalBounds;
    private Vector2 objectsize;

    public float speed = 0.05f;
    public OLDGameManagement GameManagement;

    private Collider2D objectCollider;

    private Vector2 InitialTargetPosition;

    void Start()
    {
        // Check de la taille de l'objet et des limites horizontales du monde
        objectCollider = this.GetComponent<Collider2D>();
        objectsize = objectCollider.bounds.size;
        HorizontalBounds.y = this.transform.position.y;
        HorizontalBounds.x = ((Camera.main.orthographicSize * Camera.main.aspect) - objectsize.x / 2);

        InitialTargetPosition = this.transform.position;
    }


    void Update()
    {
        if (shouldMove)
        {
            if (Vector2.Distance(this.transform.position, HorizontalBounds) > 0.0f)
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
    }

    public void LevelUp()
    {
        Debug.Log("Entered Target Level up function on Target Behavior");
        this.transform.position = InitialTargetPosition;
        this.gameObject.SetActive(true);

    }
}
