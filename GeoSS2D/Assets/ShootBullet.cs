using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {
    public GameObject bulletPrefab;

    public Transform bulletSpawn;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
	}

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Debug.Log(bullet.transform.forward);
        // Add velocity to the bullet
  //      bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        bullet.GetComponent<Rigidbody>().velocity = (new Vector3(0.0f,1.0f,0.0f)) *  6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 3.0f);
    }
}
