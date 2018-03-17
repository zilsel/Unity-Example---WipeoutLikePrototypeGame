using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinController : MonoBehaviour
{
	public Text collectedCoins;
	public Text resultText;

	private int numberOfCollectedCoins;

	// Use this for initialization
	void Start ()
	{
		this.numberOfCollectedCoins = 0;
	}

	public void CoinResult()
	{
		this.resultText.text = string.Format("You collected {0} coins", this.numberOfCollectedCoins);
	}

	public void IncrementNumberOfCollectedCoins()
	{
		this.collectedCoins.text = string.Format("{0}/60", ++numberOfCollectedCoins);
	}
}