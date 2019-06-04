using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public GameObject activeTab;

	public void changeActiveTab(GameObject newTab)
	{
		activeTab.SetActive(false);
		activeTab = newTab;
		newTab.SetActive(true);
	}
}
