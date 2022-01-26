using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    Transform respawnPt; // player respawn location
    [SerializeField]
    GameObject playerPF; // prefab for respawning player
    [SerializeField]
    int enemyCount; // # of enemies

    public int deathCount = 3;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPF, respawnPt.position, Quaternion.identity);
        deathCount--;
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 0)
            SceneManager.LoadScene("VictoryScene");

        if (gameObject.GetComponent<LevelManager>().deathCount == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene("MainMenuScene");
    }
}
