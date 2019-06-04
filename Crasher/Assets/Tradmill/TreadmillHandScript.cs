using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillHandScript : MonoBehaviour
{
	public Vector2 StartingPosition = new Vector2(0f, 1);
	public int number;
	public float speed;

	public void init(int number, float speed)
	{
		this.number = number;
		this.speed = speed;
	}

	void Update ()
	{
		if(transform.localPosition.x < 0.5)
		{
			if(number == 3)
			{
				Debug.Log("bla2");
			}
			GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
		}
		else
		{
			if (number == 3)
			{
				Debug.Log("bla");
			}
			transform.localPosition = StartingPosition;
		}
	}
}
