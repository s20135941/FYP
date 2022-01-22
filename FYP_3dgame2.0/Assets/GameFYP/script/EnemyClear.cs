using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClear : MonoBehaviour
{
    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            gameoverPanel.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
}
