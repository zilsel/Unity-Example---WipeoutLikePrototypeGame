using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
	public float coinRotationSpeed;

	private void Start()
	{
	}

	// Update is called once per frame
	private void Update ()
	{
		this.transform.Rotate(Vector3.up * Time.deltaTime * coinRotationSpeed);	
	}
}