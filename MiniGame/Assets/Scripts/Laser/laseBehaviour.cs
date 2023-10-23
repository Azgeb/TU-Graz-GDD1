using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laseBehaviour : MonoBehaviour
{
    private Vector2 boundary;
    private float objectWidth;
    private float playerWidth;
    private float ttl = 2;
    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        playerWidth = GameObject.Find("player").GetComponent<Transform>().GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        ttl = ttl - Time.deltaTime;
        if(ttl < 0) Destroy(gameObject);
        
        Vector3 playerPos = GameObject.Find("player").GetComponent<Transform>().position;
        bool isFacingRight = GameObject.Find("player").GetComponent<controll>().isFacingRight;

        Vector3 correction = new Vector3(playerWidth /2 + objectWidth /2, 0, 0);

        if(!isFacingRight){
            correction = correction*-1;
        }

        gameObject.transform.position = playerPos + correction;
    }
}
