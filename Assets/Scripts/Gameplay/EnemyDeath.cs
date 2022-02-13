using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    AudioSource enemyExplSound;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    CircleCollider2D coll;
    [SerializeField]
    EnemyShoot EnemyShoot;

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyExplSound.Play();
            sprite.enabled = false;
            coll.enabled = false;
            EnemyShoot.enabled = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }
}
