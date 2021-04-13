using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _foodFolder;
    [SerializeField] private float _spawnDelay;

    [Header("Food")]
    [SerializeField] private GameObject[] _foodTemplates;

    [Header("Obstacle")]
    [SerializeField] private float _chanceSpawnObstacle;
    [SerializeField] private GameObject[] _obstacleTemplates;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float randomValue;

        while (true)
        {
            int foodNumber = Random.Range(0, _foodTemplates.Length);
            Instantiate(_foodTemplates[foodNumber], transform.position, _foodTemplates[foodNumber].transform.rotation, _foodFolder);

            randomValue = Random.Range(0, 100);

            if(randomValue < _chanceSpawnObstacle)
            {
                yield return new WaitForSeconds(_spawnDelay);

                int obstacleNumber = Random.Range(0, _obstacleTemplates.Length);
                Instantiate(_obstacleTemplates[obstacleNumber], transform.position, _obstacleTemplates[obstacleNumber].transform.rotation, _foodFolder);
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
