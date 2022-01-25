using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPt;
    public GameObject playerPF;
    public int deathCount = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPF, respawnPt.position, Quaternion.identity);
        deathCount++;
    }
}
