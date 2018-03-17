using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemFactory : MonoBehaviour {

	public GameObject effectFire;
	public GameObject effectFireSmoke;

	private bool isFireEffectCreated;
	private bool isEffectFireSmokeInstantiated;

	// Use this for initialization
	void Start()
	{
		this.isFireEffectCreated = false;
		this.isEffectFireSmokeInstantiated = false;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void CreateFireEffect(GameObject parentGameObject)
	{
		if (!this.isFireEffectCreated)
		{
			GameObject go = Instantiate(this.effectFire, parentGameObject.transform.position, this.effectFire.transform.rotation);
			go.transform.parent = parentGameObject.transform;				// to be child of the parent object
			go.transform.localPosition = new Vector3(0f, 0f, 2f);			// reset local position of particle system
			go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);		// reset local scale of particle system
			this.isFireEffectCreated = true;
		}
	}

	public void CreateFireSmokeEffect(GameObject parentGameObject)
	{
		if (!isEffectFireSmokeInstantiated)
		{
			GameObject go = Instantiate(this.effectFireSmoke, parentGameObject.transform.position, this.effectFireSmoke.transform.rotation) as GameObject;
			go.transform.parent = parentGameObject.transform;
			this.isEffectFireSmokeInstantiated = true;
		}
	}
}