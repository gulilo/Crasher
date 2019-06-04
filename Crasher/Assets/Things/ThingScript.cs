using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThingScript : MonoBehaviour
{
	public Thing thing;

	public EventHandler exied;
	public EventHandler broke;
	public EventHandler collected;

	/*private void OnBecameInvisible()
	{
		if (exied != null)
		{
			exied(this, null);
		}
		Destroy(gameObject);
	}*/

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Spike")
		{
			brake();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Collector")
		{
			collect();
			Destroy(gameObject);
		}
	}

	private void collect()
	{
		if (collected != null)
		{
			collected(this, EventArgs.Empty);
		}
	}

	public void brake()
	{
		if (!thing.final)
		{
			Thing brakeTo = thing.brakeTo;
			for (int i = 0; i < thing.brakeAmount; i++)
			{
				ThingSpawner.spawnThing(this, brakeTo, transform.position);
			}

			if (broke != null)
			{
				broke(this, EventArgs.Empty);
			}

			Destroy(gameObject);
		}
	}


}
