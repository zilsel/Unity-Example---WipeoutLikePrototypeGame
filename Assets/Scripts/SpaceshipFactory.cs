using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFactory : MonoBehaviour {

	public GameObject spaceship;
	private bool isSpaceshipCreated;
	public GameObject spaceshipRedBlack;
	private bool isSpaceshipRedBlackCreated;
	public GameObject spaceshipViper;
	private bool isSpaceshipViperCreated;

	public GameObject gameController;
	public GameObject uiCoinController;
	public GameObject particleSystemFactory;

	// Use this for initialization
	void Start ()
	{
		this.isSpaceshipCreated = false;
		this.isSpaceshipRedBlackCreated = false;
		this.isSpaceshipViperCreated = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void CreateSpaceship(GameObject parentGameObject)
	{
		if (!this.isSpaceshipCreated)
		{
			// create spaceship:
			GameObject go = Instantiate(this.spaceship, parentGameObject.transform.position, this.spaceship.transform.rotation);
			// connect spaceship with parent:
			go.transform.parent = parentGameObject.transform;
			// add controllers to spaceship:
			go.GetComponent<SpaceshipController>().gameController = this.gameController;
			go.GetComponent<SpaceshipController>().uiCoinController = this.uiCoinController;
			go.GetComponent<SpaceshipController>().particleController = this.particleSystemFactory;

			this.isSpaceshipCreated = true;
		}
	}

	public void CreateSpaceshipRedBlack(GameObject parentGameObject)
	{
		if (!this.isSpaceshipRedBlackCreated)
		{
			// create spaceship:
			GameObject go = Instantiate(this.spaceshipRedBlack, parentGameObject.transform.position, this.spaceship.transform.rotation);
			// connect spaceship with parent:
			go.transform.parent = parentGameObject.transform;
			// add controllers to spaceship:
			go.GetComponent<SpaceshipController>().gameController = this.gameController;
			go.GetComponent<SpaceshipController>().uiCoinController = this.uiCoinController;
			go.GetComponent<SpaceshipController>().particleController = this.particleSystemFactory;

			this.isSpaceshipRedBlackCreated = true;
		}
	}

	public void CreateSpaceshipViper(GameObject parentGameObject)
	{
		if (!this.isSpaceshipViperCreated)
		{
			// create spaceship:
			GameObject go = Instantiate(this.spaceshipViper, parentGameObject.transform.position, this.spaceship.transform.rotation);
			// connect spaceship with parent:
			go.transform.parent = parentGameObject.transform;
			// add controllers to spaceship:
			go.GetComponent<SpaceshipController>().gameController = this.gameController;
			go.GetComponent<SpaceshipController>().uiCoinController = this.uiCoinController;
			go.GetComponent<SpaceshipController>().particleController = this.particleSystemFactory;

			this.isSpaceshipViperCreated = true;
		}
	}
}