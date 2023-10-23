using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyObject;
    [SerializeField] public float phaseDuration;
    [SerializeField] public float pauseBetweenPhases;
    [SerializeField] public float pauseBetweenGameObjectsWithinPhases;

    private float sinceLastPhase = 0;
    private float currentPhaseDuration = 0;
    private float sinceLastObjectWithinPhase = 0;

    private Boolean isPhaseActive = true;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isPhaseActive)
        {
            sinceLastPhase += Time.deltaTime;
            if (sinceLastPhase > pauseBetweenPhases)
            {
                sinceLastPhase = 0;
                isPhaseActive = true;
            }
        }
        else
        {
            sinceLastObjectWithinPhase += Time.deltaTime;
            currentPhaseDuration += Time.deltaTime;
            if (sinceLastObjectWithinPhase > pauseBetweenGameObjectsWithinPhases)
            {
                sinceLastObjectWithinPhase = 0;
                Instantiate(enemyObject, new Vector3(transform.position.x, ((float)rand.NextDouble() * 10) - 5, transform.position.z), enemyObject.transform.rotation);
            }

            if (currentPhaseDuration > phaseDuration)
            {
                currentPhaseDuration = 0;
                isPhaseActive = false;
            }
        }
    }
}
