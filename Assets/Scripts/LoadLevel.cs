using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public bool levelLoadWithName = false;
    public string levelName;

    public bool levelLoadWithIndex = false;
    public int levelIndex;

    private void load(){
        if(levelLoadWithName){
            Application.LoadLevel(levelName);
        }
        else if(levelLoadWithIndex){
            Application.LoadLevel(levelIndex);
        }
        else if(levelLoadWithName && levelLoadWithIndex){
            Debug.Log("You can't load level with name and index at the same time");
        }
        else{
            Debug.Log("You can't load level without name or index");
        }
    }

    // Start is called before the first frame update
 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        load();     
    }

}
