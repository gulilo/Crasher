using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerAreaScript : MonoBehaviour
{
	public Thing currentlySpawning;
	public float spawnTime;
	public List<float> spawnerTimes;

	public EventHandler<EventArgs<float>> SpawnTimeChanged;
	public EventHandler<EventArgs<Thing>> thingChanged;
	public EventHandler spawnerAdded;

	private void Start()
	{
		spawnerTimes = new List<float>();
		spawnerTimes.Add(0);
	}

	private void Update()
	{
		for(int i = 0; i < spawnerTimes.Count;i++)
		{
			if (spawnerTimes[i] < spawnTime)
			{
				spawnerTimes[i] += Time.deltaTime;
			}
			else
			{
				spawn();
				spawnerTimes[i] = 0;
			}
		}
	}

	private void spawn()
	{
		float areaSize = transform.localScale.x;
		Vector2 position = new Vector2(UnityEngine.Random.Range(-0.5f * areaSize, 0.5f* areaSize),transform.position.y);
		GameObject thing = ThingSpawner.spawnThing(this, currentlySpawning, position);
	}

	public void changeSpawn(Thing newThing)
	{
		currentlySpawning = newThing;
		if (thingChanged != null)
		{
			thingChanged(this, new EventArgs<Thing>(newThing));
		}
	}

	public void changeSpawningTime(float newTime)
	{
		spawnTime = Mathf.Max(0.1f,spawnTime + newTime); 
		if(SpawnTimeChanged != null)
		{
			SpawnTimeChanged(this, new EventArgs<float>(newTime));
		}
	}

	public void addSpawner()
	{
		spawnerTimes.Add(0);

		if(spawnerAdded != null)
		{
			spawnerAdded(this, EventArgs.Empty);
		}
	}
}
