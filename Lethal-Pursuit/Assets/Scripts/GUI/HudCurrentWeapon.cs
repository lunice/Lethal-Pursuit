﻿using UnityEngine;
using System;
using System.Collections;

public class HudCurrentWeapon : MonoBehaviour {

	private SpaceshipPickups pickupsComponent;
	private UI2DSprite currentWeaponSprite;

	public Sprite defaultLaser;
	public Sprite auroraCannon;
	public Sprite punkMissiles;
	public Sprite stickyMines;

	// Use this for initialization
	void Start () {
		currentWeaponSprite = GetComponent<UI2DSprite>();
	}
	
	// Update is called once per frame
	void Update () {

		if (pickupsComponent == null) {
			Spaceship ship = GameplayManager.spaceship;
			if (ship != null) {
				pickupsComponent = ship.GetComponent<SpaceshipPickups>();
			}
		}
		else {
			if (pickupsComponent.currentPickup == null || !pickupsComponent.pickupIsActive) {
				currentWeaponSprite.sprite2D = defaultLaser;
			}
			else if (pickupsComponent.currentPickup is AuroraCannon) {
				currentWeaponSprite.sprite2D = auroraCannon;
			}
			else {
				throw new Exception("HudCurrentWeapon(); Unrecognized pickup type: " + pickupsComponent.currentPickup);
			}
		}
	}
}
