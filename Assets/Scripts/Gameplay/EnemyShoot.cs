using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPF;
    public Transform bulletSpawn;
    public Transform sightStart, sightEnd;
    public bool spotted = false;
    float fireRate = 3f;
    float ttns; // time to next shot
    public Rigidbody2D rb;
    public bool isFacingRight;

    void Update()
    {
        directionCheck();

        // TODO: Rewrite all of this to match the player's shooting. Fire left or right when moving either way, possibly regardless of movement direction.
    }

    
    void directionCheck()
    {
        if (rb.velocity.x > 0)
            isFacingRight = true;
        else if (rb.velocity.x < 0)
            isFacingRight = false;
    }
}
