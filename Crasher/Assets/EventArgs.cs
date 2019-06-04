using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArgs<T> : EventArgs
{
	public T value { get; private set; }
	public EventArgs(T value)
	{
		this.value = value;
	}
}
