using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public bool spawningAllowed = false;
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.player.GetComponent<PlayerMovement>().dead)
        {
            SpawnEnemy();
        }
        
    }

    private void SpawnEnemy()
    {
        if (spawningAllowed && Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < 104 && Time.time > spawnTimer)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
