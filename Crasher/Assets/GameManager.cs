using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public SpawnerAreaScript SpawnersArea;

	public int money;

	public EventHandler<EventArgs<int>> moneyChanged;

	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		ThingSpawner.thingSpawned += onThingSpawn;
	}

	void onThingSpawn(object o, EventArgs<ThingScript> args)
	{
		Debug.Log("thingspawn");
		ThingScript thingScript = args.value;
		Thing thing = thingScript.thing;

		if (!thing.final)
		{
			thingScript.broke += onThingBroke;// i guess i can use the sender for somthing here...
		}
		thingScript.collected += onThingCollected;
	}

	void onThingBroke(object o, EventArgs args)
	{
		((ThingScript)o).collected -= onThingCollected;
		((ThingScript)o).broke -= onThingBroke;
	}

	void onThingCollected(object o, EventArgs args)
	{
		Debug.Log("thingcollected");
		ThingScript thingScript = (ThingScript)o;

		if (thingScript.thing.final)
		{
			changeMoney(thingScript.thing.worth);
		}

		thingScript.collected -= onThingCollected;
	}

	public void changeMoney(int amount)
	{
		money += amount;
		if (moneyChanged != null)
		{
			moneyChanged(this, new EventArgs<int>(money));
		}
	}
}
