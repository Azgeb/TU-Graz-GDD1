using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameoverHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private int score; 
    private int highscore; 
    
    int len = 5;
    void Start()
    {
        score = PlayerPrefs.GetInt("LastScore");
        highscore = PlayerPrefs.GetInt("Highcore");
        if(score > highscore) highscore = score;
        PlayerPrefs.SetInt("Highcore", highscore);

        GameObject.Find("Numeric").GetComponent<TextMeshProUGUI>().text =  score.ToString("D" + len.ToString());
        GameObject.Find("HSNumeric").GetComponent<TextMeshProUGUI>().text = highscore.ToString("D" + len.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
