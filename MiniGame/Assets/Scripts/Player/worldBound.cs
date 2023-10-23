using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldBound : MonoBehaviour
{
    private Vector2 boundary;
    private float objectHeight;
    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, boundary.x * -1 + objectWidth/2, boundary.x - objectWidth/2);
        pos.y = Mathf.Clamp(pos.y, boundary.y* -1 + objectHeight/2, boundary.y - objectHeight/2);
        transform.position = pos;
    }
}
