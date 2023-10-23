using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class laserSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject laserObject;
    private float cooldown = 4;
    private float timeSinceLaser = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLaser = timeSinceLaser + Time.deltaTime;
        if (timeSinceLaser > cooldown && Input.GetKey(KeyCode.L)){
            timeSinceLaser = 0;
            Instantiate(laserObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), laserObject.transform.rotation);
        }
    }
}
