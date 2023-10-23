using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    
    [SerializeField] public GameObject freezePowerUp;
    System.Random rand = new System.Random();
    public float nextSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn = nextSpawn - Time.deltaTime;
        if(nextSpawn<0){
            Instantiate(freezePowerUp, new Vector3(((float)rand.NextDouble() * 10) - 5, ((float)rand.NextDouble() * 10) - 5, transform.position.z), freezePowerUp.transform.rotation);
            nextSpawn = (float)rand.NextDouble() * 60;
        }
        
    }
}
