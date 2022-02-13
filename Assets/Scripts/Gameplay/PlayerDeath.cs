using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDeath : MonoBehaviour
{
    public GameObject explosion;
    public static PlayerDeath Instance;
    [SerializeField]
    AudioSource deathExplSound;
    [SerializeField]
    SpriteRenderer rend;
    [SerializeField]
    BoxCollider2D boxCol;

    private void Start()
    {
        Instance = this;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathExplSound.Play();
            rend.enabled = false;
            boxCol.enabled = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }
}