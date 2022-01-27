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
    [SerializeField]
    Transform playerObj;
    [SerializeField]
    LayerMask enemyLayer;


    float cooldown = 0f;
    EnemyPatrol enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        FireControlGroup(enemy.isFacingRight);
        if (PlayerDeath.Instance != null)
            Debug.DrawRay(gun.position, PlayerDeath.Instance.transform.position - gun.position);
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
            RaycastHit2D test = Physics2D.Raycast(gun.position, (PlayerDeath.Instance.transform.position - gun.position), 10f, enemyLayer);
            if (test.collider == false)
            {
                // Debug.DrawRay(gun.position, new Vector3(10f, gun.localPosition.y, gun.localPosition.z));
                RaycastHit2D hit = Physics2D.Raycast(gun.position, (PlayerDeath.Instance.transform.position - gun.position), 10f, player);
                if (hit.collider != false && cooldown < Time.time)
                {

                    Fire();
                    cooldown = Time.time + fireRate;
                }
            }
        }
        else if (right == false)
        {
            RaycastHit2D test = Physics2D.Raycast(gun.position, (PlayerDeath.Instance.transform.position - gun.position), 10f, enemyLayer);
            if (test.collider == false)
            {
                // Debug.DrawRay(gun.position, new Vector3(-10f, gun.localPosition.y, gun.localPosition.z));
                RaycastHit2D hit = Physics2D.Raycast(gun.position, (PlayerDeath.Instance.transform.position - gun.position), 10f, player);
                if (hit.collider != false && cooldown < Time.time)
                {
                    Fire();
                    cooldown = Time.time + fireRate;
                }
            }
        }
    }

    /*public void ShootAtPlayer()
    {
        Debug.DrawRay(gun.position, playerObj.transform.position - gun.position);
        RaycastHit2D hit = Physics2D.Raycast(gun.position, playerObj.transform.position - gun.position, 10f, player);

        if (hit.transform.tag == "Player")
        {

        }
    }*/
}
