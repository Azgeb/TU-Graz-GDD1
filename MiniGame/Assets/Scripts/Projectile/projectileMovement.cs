using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7;

    private Rigidbody2D rigidbody;
    private Vector2 boundary;
    private Boolean changeDirection = false;
    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -(boundary.x * 1.5) || transform.position.x > (boundary.x * 1.5)) Destroy(gameObject);

        if (changeDirection)
        {
            changeDirection = false;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * -1, rigidbody.velocity.y); ;
        }

    }

    public void PlayerFacing(Boolean isFacingRight)
    {
        if (!isFacingRight)
        {
            changeDirection = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
