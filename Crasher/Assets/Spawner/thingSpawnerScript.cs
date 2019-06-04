using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// maybe split to obejct spawner and thing manager
public class thingSpawnerScript : MonoBehaviour
{
	public Thing thingToSpawn;
	public float timePassed;
	public float timeToSpawn;

	public void init(SpawnerAreaScript area, Thing CurrentlySpawning, float spawnTime)//find a way to send the event handler
	{
		area.thingChanged += (sender, args) => { thingToSpawn = args.value; };
		area.SpawnTimeChanged += (sender, args) => { timeToSpawn = ((SpawnerAreaScript)sender).spawnTime; };//maybe change timepassed too?
		thingToSpawn = CurrentlySpawning;
		timeToSpawn = spawnTime;
	}

	private void Update()
	{
		if(timePassed < timeToSpawn)
		{
			timePassed += Time.deltaTime;
		}
		else
		{
			spawn();
			timePassed = 0;
		}
	}

	private void spawn()
	{
		ThingSpawner.spawnThing(this, thingToSpawn, transform.position);
	}
}


