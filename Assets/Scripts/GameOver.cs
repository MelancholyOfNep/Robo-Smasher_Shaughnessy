using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<LevelManager>().deathCount >= 3)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
