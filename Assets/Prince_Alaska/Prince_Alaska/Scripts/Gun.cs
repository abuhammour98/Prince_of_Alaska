using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle; // The point where bullets are spawned
    public GameObject bulletPrefab; // Prefab of the bullet

    public float bulletSpeed = 10f; // Speed of the bullet

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming you use the left mouse button for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = muzzle.forward * bulletSpeed;
    }
}
