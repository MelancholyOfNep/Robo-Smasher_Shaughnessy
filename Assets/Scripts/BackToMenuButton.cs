using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        StartCoroutine(AsyncSceneLoad());
    }

    IEnumerator AsyncSceneLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenuScene");

        // Wait until the scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
