using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thing", menuName = "Thing", order = 1)]
public class Thing : ScriptableObject
{
	public bool final;
	public int worth;
	public GameObject prefab;
	public Thing brakeTo;
	public int brakeAmount;
}
