using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesCounterUI : MonoBehaviour
{
    [SerializeField]
    int livesPlaceholder;
    [SerializeField]
    TextMeshProUGUI livesText;

    public GameObject lvlManager;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesPlaceholder = lvlManager.GetComponent<LevelManager>().deathCount;
        livesText.text = livesPlaceholder.ToString();
    }
}
