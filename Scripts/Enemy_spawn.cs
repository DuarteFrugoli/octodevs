using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;
    public float minSpawnTime;
    public float maxSpawmTime;

    private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        
        Vector3 aux = Random.insideUnitCircle * 20;
        Vector3 pos = player.transform.position + aux;

        if(timeUntilSpawn <= 0)
        {
            Instantiate(enemy, pos, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawmTime);
    }
}
