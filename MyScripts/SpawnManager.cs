using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private GameObject[] powerupPrefab = new GameObject[3];
    [SerializeField] private bool stopspawning = false;
    // Start is called before the first frame update
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3.0f);

        while (stopspawning == false)
        {
            Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(-8, 8), 7, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(3.5f);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(3.0f);

        while (stopspawning == false)
        {
            Vector3 spawnPoint2 = new Vector3(UnityEngine.Random.Range(-8, 8), 7, 0);
            int randomIndex = UnityEngine.Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[randomIndex], spawnPoint2, Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(3f, 7f));
        }
    }

    public void OnPlayerDeath()
    {
        stopspawning = true;
    }


}
