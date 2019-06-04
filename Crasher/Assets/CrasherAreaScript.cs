using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrasherAreaScript : MonoBehaviour
{
	public CrasherScript leftCrasher, rightCrasher;

	public float rotationSpeed;
	public EventHandler<EventArgs<float>> rotationSpeedChanged;

	public int numberOfSpikes = 3;
	public EventHandler<EventArgs<int>> spikeAdded;
	public float spikeSize;
	public EventHandler<EventArgs<float>> spikeSizeChanged;

	private void Start()
	{
		leftCrasher = transform.GetChild(0).GetComponent<CrasherScript>();
		rightCrasher = transform.GetChild(1).GetComponent<CrasherScript>();
	}

	public void changeRotation(float changeBy)
	{
		leftCrasher.changeRotation(changeBy);
		rightCrasher.changeRotation(changeBy);

		if (rotationSpeedChanged != null)
		{
			rotationSpeedChanged(this, new EventArgs<float>(rotationSpeed));
		}
	}

	public void addSpike()
	{
		leftCrasher.addSpike();
		rightCrasher.addSpike();
		numberOfSpikes++;

		if (spikeAdded != null)
		{
			spikeAdded(this, new EventArgs<int>(numberOfSpikes));
		}
	}

	public void ChangeSpikeSize(float changeBy)
	{
		leftCrasher.changeSpikeSize(changeBy);
		rightCrasher.changeSpikeSize(changeBy);

		if (spikeSizeChanged != null)
		{
			spikeSizeChanged(this, new EventArgs<float>(spikeSize));
		}
	}
}
