using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public int maxSceneCount;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene());
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }

    }


    private void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == maxSceneCount)
        {
            return;
        }
        else
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(LoadLevel(currentLevelIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelIndex);
    }
}
