﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject EnemyGo;

	float maxSpawnRateInSeconds = 3f;

	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
		anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

		nextSpawn();
	}

    void nextSpawn()
	{
		float spawnInNSeconds;

		if (maxSpawnRateInSeconds > 1f)
		{
			spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		}
		else
			spawnInNSeconds = 1f;

		Invoke("Spawner", spawnInNSeconds);
	}

    void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
    public void StartEnemySpawner()
    {
        Invoke("Spawner", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);

    }
    public void StopEnemySpawner()
    {
        CancelInvoke("Spawner");
        CancelInvoke("IncreaseSpawnRate");
    }
}
