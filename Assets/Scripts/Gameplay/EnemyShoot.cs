using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    float fireRate;
    [SerializeField]
    Transform gun;
    [SerializeField]
    GameObject bulletPF;
    [SerializeField]
    LayerMask player;


    float cooldown = 0f;
    EnemyPatrol enemy;

    // Start is called before the first frame update
    private void Start()
    {
        enemy = gameObject.GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    private void Update()
    {
        FireControlGroup(enemy.isFacingRight);
    }

    void Fire()
    {
        float angle = enemy.isFacingRight ? 0f : 180f;
        Instantiate(bulletPF, gun.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    void FireControlGroup(bool right)
    {
        if (right == true)
        {
            
            Debug.DrawRay(gun.position, new Vector3(10f, gun.localPosition.y, gun.localPosition.z));
            RaycastHit2D hit = Physics2D.Raycast(gun.position, new Vector3(10f, gun.localPosition.y, gun.localPosition.z), 10f, player);
            if (hit.collider != false && cooldown < Time.time)
            {
                
                Fire();
                cooldown = Time.time + fireRate;
            }
        }
        else if (right == false)
        {
            
            Debug.DrawRay(gun.position, new Vector3(-10f, gun.localPosition.y, gun.localPosition.z));
            RaycastHit2D hit = Physics2D.Raycast(gun.position, new Vector3(-10f, gun.localPosition.y, gun.localPosition.z), 10f, player);
            if (hit.collider != false && cooldown < Time.time)
            {
                
                Fire();
                cooldown = Time.time + fireRate;
            }
        }
    }
}
