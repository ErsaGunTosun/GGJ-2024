using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused ;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false ;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pausePanel.SetActive(isPaused);
        }
    }
}
