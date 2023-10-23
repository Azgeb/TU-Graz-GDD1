using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMonvement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public GameObject game;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float magnitute = 0.05f;
    [SerializeField] private float frequency = 5f;
    System.Random rand = new System.Random();
    private Vector2 boundary;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        speed = speed * 1 + (float)rand.NextDouble();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game").GetComponent<service>().isEnemyMoving)
        {
            if (transform.position.x < -(boundary.x * 1.5) || transform.position.x > (boundary.x * 1.5)) Destroy(gameObject);

            Vector3 newPos = transform.position;
            newPos -= transform.right * Time.deltaTime * speed;
            transform.position = newPos + transform.up * Mathf.Sin(Time.time * frequency) * magnitute;
        }
    }
}
