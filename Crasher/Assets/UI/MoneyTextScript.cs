using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextScript : MonoBehaviour
{
	public Text t;

	void Start ()
	{
		Text text = gameObject.GetComponent<Text>();
		GameManager.Instance.moneyChanged += onMoneyChanged; // dont forget to stop listening
	}

	private void OnDestroy()
	{
		GameManager.Instance.moneyChanged -= onMoneyChanged;
	}

	public void onMoneyChanged(object o, EventArgs<int> args)
	{
		GetComponent<Text>().text = "" + args.value;
	}
}
