using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThingSpawner : MonoBehaviour
{
	public static EventHandler<EventArgs<ThingScript>> thingSpawned;

	public static GameObject spawnThing(object sender,Thing toSpawn, Vector2 whereToSpwan)
	{
		GameObject go = Instantiate(toSpawn.prefab, whereToSpwan, Quaternion.identity);

		if(thingSpawned != null)
		{
			thingSpawned(sender, new EventArgs<ThingScript>(go.GetComponent<ThingScript>()));
		}

		return go;
	}
}
