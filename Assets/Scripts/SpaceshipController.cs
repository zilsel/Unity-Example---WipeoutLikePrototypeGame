using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour
{
    public float spaceshipSpeed;
	private int maxCountOfCollisionWithTunnel;

	#region Controllers

	public GameObject gameController;
	public GameObject uiCoinController;
	public GameObject particleController;

	#endregion Controllers

	private void Start()
	{
		this.maxCountOfCollisionWithTunnel = 3;
		this.gameController.GetComponent<GameController>().gameStarted = false;
	}

	// Update is called once per frame
	private void Update ()
	{
		if(!gameController.GetComponent<GameController>().canDrive)
		{
			if(gameController.GetComponent<GameController>().gameStarted)
			{
				this.uiCoinController.GetComponent<UICoinController>().CoinResult();
				this.particleController.GetComponent<ParticleSystemFactory>().CreateFireEffect(this.gameObject);
			}
			return;
		}

		// left direction
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Translate(Vector3.right * Time.deltaTime);
		}

		// right direction
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Translate(Vector3.left * Time.deltaTime);
		}

		// Up direction
		if (Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.Translate(Vector3.up * Time.deltaTime);
		}

		// Down direction
		if (Input.GetKey(KeyCode.DownArrow))
		{
			this.transform.Translate(Vector3.down * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Coin")
		{
			this.uiCoinController.GetComponent<UICoinController>().IncrementNumberOfCollectedCoins();
			Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "DangerObstacle")
		{
			// stop game:
			this.gameController.GetComponent<GameController>().canDrive = false;
			col.rigidbody.useGravity = true;
			this.GetComponent<Rigidbody>().useGravity = true;
		}

		if (col.gameObject.tag == "PlatformLevel" && --this.maxCountOfCollisionWithTunnel == 0)
		{
			this.particleController.GetComponent<ParticleSystemFactory>().CreateFireSmokeEffect(this.gameObject);
		}
	}
}