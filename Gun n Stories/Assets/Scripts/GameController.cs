using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemy,Player;
    float Zmax = 125, Zmin = -125;
    float Xmax = 125, Xmin = -125;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-125,125),0, UnityEngine.Random.Range(-125,125));
            Instantiate(enemy,spawnPosition,Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
