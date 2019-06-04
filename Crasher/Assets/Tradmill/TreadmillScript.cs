using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreadmillScript : MonoBehaviour
{
	public GameObject TreadmillHandPrefab;
	public float handSpeed;

	private List<GameObject> hands;

	public EventHandler<EventArgs<TreadmillHandScript>> TreadmillHandAdded;

	private void Start()
	{
		hands = new List<GameObject>();
		AddHand();
	}

	public void AddHand()
	{
		GameObject newHand = Instantiate(TreadmillHandPrefab,transform);
		hands.Add(newHand);
		newHand.GetComponent<TreadmillHandScript>().init(hands.Count, handSpeed);

		for(int i = 0; i < hands.Count;i++)
		{
			hands[i].transform.localPosition = new Vector2(-0.5f * (i+1), 1);
		}

		if(TreadmillHandAdded != null)
		{
			TreadmillHandAdded(this, new EventArgs<TreadmillHandScript>(newHand.GetComponent<TreadmillHandScript>()));
		}
	}
}
