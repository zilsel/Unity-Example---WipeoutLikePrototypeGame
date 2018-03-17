using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject gameOverPanel;
	public GameObject gameController;
	public Text playerNameInputField;
	public Text playerName;

	// Use this for initialization
	void Start()
	{
		this.gameOverPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (!this.gameController.GetComponent<GameController>().canDrive &&
			this.gameController.GetComponent<GameController>().gameStarted)
		{
			this.gameOverPanel.SetActive(true);
		}
	}

	#region Player Methods

	public void SetPlayerName()
	{
		this.playerName.text = string.Format("{0}, you are playing prototype game", this.playerNameInputField.text);
	}

	#endregion Player Methods
}