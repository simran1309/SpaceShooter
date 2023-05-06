using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public GameObject tripleShotPrefab;
    public GameObject SpeedBoostPrefab;
    public GameObject ShieldPrefab;
    public GameObject AestroidPrefab;
    [SerializeField]
    public GameObject EnemyContainer;
    public bool StopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnTripleShot());
        StartCoroutine(SpawnSpeedBoost()); 
        StartCoroutine(SpawnSheild()); 
        StartCoroutine(SpawnAestroid());
    }

    // Update is called once per frame                                                                                                                                                                                                                                                                    
    void Update()
    {
        
    }
    IEnumerator SpawnRoutine()
    {
        while (StopSpawning==false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-5f, 5f), 7, 0);
           GameObject newEnemy= Instantiate(SpawnPrefab, spawnpos, Quaternion.identity);
            newEnemy.transform.parent = EnemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator SpawnTripleShot()
    {
        while (StopSpawning == false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-5f, 5f), 7, 0);
            GameObject newEnemy = Instantiate(tripleShotPrefab, spawnpos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4,8));
        }
    }
    IEnumerator SpawnSpeedBoost()
    {
        while (StopSpawning == false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-5f, 5f), 7, 0);
            GameObject newEnemy = Instantiate(SpeedBoostPrefab, spawnpos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }
    IEnumerator SpawnAestroid()
    {
        while (StopSpawning == false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-5f, 5f), 7, 0);
            GameObject newEnemy = Instantiate(AestroidPrefab, spawnpos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }
    IEnumerator SpawnSheild()
    {
        while (StopSpawning == false)
        {
            Vector3 spawnpos = new Vector3(Random.Range(-5f, 5f), 7, 0);
            GameObject newEnemy = Instantiate(ShieldPrefab, spawnpos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }
    public void OnPlayerDeath()
    {
        StopSpawning = true;
    }
}
