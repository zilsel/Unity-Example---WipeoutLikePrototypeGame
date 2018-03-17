using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public bool canDrive;
	public bool gameStarted;
	public bool isShipSelected;

	// Use this for initialization
	void Start ()
	{
		this.canDrive = true;
		this.gameStarted = false;
		this.isShipSelected = false;
	}
}