using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpaceshipController : MonoBehaviour
{
	public Image spaceshipImage;
	public Image spaceshipRedBlackImage;
	public Image spaceship3Image;

	public GameObject choseSpaceshipPanel;
	public GameObject gameController;
	public GameObject spaceshipHolder;
	public GameObject spaceshipFactory;

	private int selectedIndexData;
	private int indexData;
	private int prevIndexData;
	private List<SpaceshipData> spaceshipData;

	private struct SpaceshipData
	{
		public Image SpaceshipImage;
		public string SpaceshipName;
	};

	public void NextShip()
	{
		this.selectedIndexData = this.indexData;
		this.spaceshipData[this.indexData++].SpaceshipImage.enabled = true;
		this.spaceshipData[this.prevIndexData].SpaceshipImage.enabled = false;

		if (this.indexData == this.spaceshipData.Count)
		{
			this.indexData = 0;
			this.prevIndexData = this.spaceshipData.Count - 1;
		}
		else
		{
			this.prevIndexData = this.indexData - 1;
		}
	}

	private void CreateSpaceship()
	{
		if (this.gameController.GetComponent<GameController>().isShipSelected)
		{
			switch (this.spaceshipData[this.selectedIndexData].SpaceshipName)
			{
				case "Spaceship Beginner":
					this.spaceshipFactory.GetComponent<SpaceshipFactory>().CreateSpaceship(this.spaceshipHolder.gameObject);
					break;
				case "Spaceship Dragon":
					this.spaceshipFactory.GetComponent<SpaceshipFactory>().CreateSpaceshipRedBlack(this.spaceshipHolder.gameObject);
					break;
				case "Spaceship Viper":
					this.spaceshipFactory.GetComponent<SpaceshipFactory>().CreateSpaceshipViper(this.spaceshipHolder.gameObject);
					break;
			}
		}
	}

	public void ShipIsSet()
	{
		this.gameController.GetComponent<GameController>().isShipSelected = true;
		choseSpaceshipPanel.GetComponent<CanvasGroup>().alpha = 0f;
	}

	// Use this for initialization
	void Start ()
	{
		this.choseSpaceshipPanel.GetComponent<CanvasGroup>().alpha = 1f;
		this.choseSpaceshipPanel.GetComponent<CanvasGroup>().interactable = true;
		this.choseSpaceshipPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

		// create spaceship data:
		this.spaceshipData = new List<SpaceshipData>();
		this.spaceshipImage.enabled = true;
		this.spaceshipData.Add(new SpaceshipData() { SpaceshipImage = this.spaceshipImage, SpaceshipName = "Spaceship Beginner" });
		this.spaceshipRedBlackImage.enabled = false;
		this.spaceshipData.Add(new SpaceshipData() { SpaceshipImage = this.spaceshipRedBlackImage, SpaceshipName = "Spaceship Dragon" });
		this.spaceship3Image.enabled = false;
		this.spaceshipData.Add(new SpaceshipData() { SpaceshipImage = this.spaceship3Image, SpaceshipName = "Spaceship Viper" });

		this.selectedIndexData = 0;
		this.indexData = 1;
		this.prevIndexData = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		CreateSpaceship();  // create spaceship if spaceship is selected
	}
}