using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controll : MonoBehaviour
{
    [SerializeField] private float speed = 7;

    private Rigidbody2D rigidbody;  
    [SerializeField] public GameObject projectile;
    public bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(0, 0);
        int speedModifierX = 0;
        int speedModifierY = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) speedModifierX = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) speedModifierX = -1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) speedModifierY = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) speedModifierY = -1;

        
        if (Input.GetKeyDown(KeyCode.Space)) {
            int projectileRotation = 90;
            if(isFacingRight) projectileRotation *= -1;
            var projectileInstance = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectile.transform.rotation);
            projectileInstance.GetComponent<projectileMovement>().PlayerFacing(isFacingRight);
        }

        if (speedModifierX == -1 && isFacingRight || speedModifierX == 1 && !isFacingRight){
            Flip();
        }

        rigidbody.velocity = new Vector2(speed * speedModifierX, speed * speedModifierY);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        var scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject.Find("Game").GetComponent<service>().isEnemyMoving = false;
            PlayerPrefs.SetInt("LastScore", GameObject.Find("Game").GetComponent<service>().scoreCounter);
            Destroy(gameObject);
            SceneManager.LoadScene("Gameover");
        }

         if (other.CompareTag("Freeze"))
        {
           GameObject.Find("Game").GetComponent<service>().isEnemyMoving = false;
        }
    }
}
