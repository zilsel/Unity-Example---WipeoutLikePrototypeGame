using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
	public float cameraSpeed;
	public float rotationSpeed;
	public GameObject gameController;

	private void FixedUpdate()
	{
		if (this.gameController.GetComponent<GameController>().isShipSelected && Input.GetKey(KeyCode.Return))
		{
			this.gameController.GetComponent<GameController>().gameStarted = true;
		}

		if (!this.gameController.GetComponent<GameController>().gameStarted)
		{
			return;
		}

		if (this.gameController.GetComponent<GameController>().canDrive)
		{
			this.transform.Translate(Vector3.forward * Time.deltaTime * cameraSpeed);

			if (Input.GetKey(KeyCode.A))
			{
				this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
			}

			if (Input.GetKey(KeyCode.D))
			{
				this.transform.Rotate(Vector3.forward * Time.deltaTime * -rotationSpeed);
			}
		}
	}
}