using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public float duration = 5;
    float ttl = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        ttl = ttl - Time.deltaTime;
        if(ttl < 0 && gameObject.transform.position.x != -2000) Destroy(gameObject);

        if( gameObject.transform.position.x == -2000){
            duration = duration - Time.deltaTime;
            if(duration < 0){
                GameObject.Find("Game").GetComponent<service>().isEnemyMoving = true;
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
       if (other.CompareTag("Player"))
        {
           Vector2 newPos = gameObject.transform.position;
           newPos.x = -2000;
           gameObject.transform.position = newPos;
        }
    }
}
