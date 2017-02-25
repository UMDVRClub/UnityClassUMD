using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Transform bulletSpawnTransform;
	public Rigidbody2D bulletPrefab;
	public float bulletSpeed;
	public float maxFireDelay;

	private float currentFireDelay;
	private bool canShootAfterDelay = true;

	public void Fire(){
		if (canShootAfterDelay) {
			Rigidbody2D instantiatedBullet = Instantiate (bulletPrefab, bulletSpawnTransform.position, transform.rotation);
			instantiatedBullet.velocity = transform.up * bulletSpeed;
			Destroy (instantiatedBullet.gameObject, 1);
			canShootAfterDelay = false;
		}
	}

	void Update(){
		currentFireDelay += Time.deltaTime;

		if (currentFireDelay >= maxFireDelay) {
			currentFireDelay = 0;
			canShootAfterDelay = true;
		}
	}
}
