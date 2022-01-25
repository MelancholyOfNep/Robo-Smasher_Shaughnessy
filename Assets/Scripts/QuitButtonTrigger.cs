using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonTrigger : MonoBehaviour
{
    public void onButtonPress()
    {
        Application.Quit();
    }
}
