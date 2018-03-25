using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private Vector2 HorizontalBorder;
    private Vector2 ObjectSize;
    private float Speed;

    public float MinSpeed = 0.02f;
    public float MaxSpeed = 0.05f;

void Start()
    {
        ObjectSize = this.GetComponent<Collider2D>().bounds.size;
        HorizontalBorder = new Vector2(((Camera.main.orthographicSize * Camera.main.aspect) - ObjectSize.x /2), this.transform.position.y);

        Speed = Random.Range(MinSpeed, MaxSpeed);
    }

    void Update()
    {
        if (Vector2.Distance(this.transform.position, HorizontalBorder) > 0.0f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, HorizontalBorder, Speed);

        }
        else
        {
            HorizontalBorder.x = HorizontalBorder.x * -1;
        }

        if (HorizontalBorder.x > this.transform.position.x)
        {
            this.transform.Rotate(new Vector3(0, 0, -360) * Time.deltaTime, Space.Self);
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime, Space.Self);
        }
    }
}
