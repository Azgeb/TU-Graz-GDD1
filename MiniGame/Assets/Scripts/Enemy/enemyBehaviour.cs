using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    int scoreCounter = 0;
    int len = 5;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag ("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            GameObject.Find("Game").GetComponent<service>().scoreCounter++;
            GameObject.Find("scoreNumeric").GetComponent<TextMeshProUGUI>().text =  GameObject.Find("Game").GetComponent<service>().scoreCounter.ToString("D" + len.ToString());
            Destroy(gameObject);
        }
    }
}
