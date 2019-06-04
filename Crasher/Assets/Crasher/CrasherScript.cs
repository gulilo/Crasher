using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrasherScript : MonoBehaviour
{
	public GameObject CrasherHandPrefab;

	public float rotationSpeed;

	private List<GameObject> spikes;

	private void Start()
	{
		spikes = new List<GameObject>();
		addSpike();
		addSpike();
		addSpike();
	}

	void Update()
	{
		transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
	}

	public void changeRotation(float changeBy)
	{
		rotationSpeed += changeBy;
	}


	public void addSpike()
	{
		GameObject newSpike = Instantiate(CrasherHandPrefab, transform);
		spikes.Add(newSpike);

		float angleBetween = 360 / (spikes.Count);
		Debug.Log(spikes.Count +"    "+ angleBetween);
		for (int i = 0; i < spikes.Count; i++)
		{
			float x = Mathf.Cos(Mathf.Deg2Rad * angleBetween * i);
			float y = Mathf.Sin(Mathf.Deg2Rad * angleBetween * i);
			spikes[i].transform.localPosition = new Vector2(0.5f * x, 0.5f * y);
			//spikes[i].transform.rotation =  new Quaternion(new Vector3 (0,0, angleBetween * i)); // not working
		}
	}

	public void changeSpikeSize(float changeBy)
	{
		throw new NotImplementedException();// change scale on x and half as much in potions x
	}
}
