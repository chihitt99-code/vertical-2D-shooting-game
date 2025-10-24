using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] enemyPoints;
    

    private float delta = 0;
    private float span = 2;
    
    void Update()
    {
        delta += Time.deltaTime;

        if (delta >= span)
        {
            Debug.Log("적을생성");
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0,3)];
            Transform enemyPoint = enemyPoints[Random.Range(0, enemyPoints.Length)];

            Instantiate(enemyPrefab, enemyPoint.position, enemyPoint.rotation);
            
            span = Random.Range(1.5f, 2.5f);
            

            delta = 0;
        }
        
        
    }

   
}
