using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

enum MyEnum
{
    UP = 1,
    DOWN = 2,
    RIGHT = 3,
    LEFT = 4
}

public class QuickTime : MonoBehaviour
{
    [SerializeField] int maxArrow = 6;
    [SerializeField] int nextLevelID = 0;
    [SerializeField] float time = 0.3f;
    [SerializeField] float delayTime = 4.2f;
    [SerializeField] public int sayac = 0;

    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;

    Vector2 vector1;

    public Animator animator;

    void Start()
    {
        sayac = 0;

        vector1 = gameObject.transform.position;

        StartCoroutine(spawnBlock());
    }

    //Create Object 
    private void createObject()
    {
        int randomNumber = randomNumbers();

        if (randomNumber == (int)MyEnum.UP)
        {
            GameObject UpBox = Instantiate(Up);
            UpBox.name = "Up";
            UpBox.SetActive(true);
            UpBox.transform.position = vector1;
        }
        else if (randomNumber == (int)MyEnum.DOWN)
        {
            GameObject UpBox = Instantiate(Down);
            UpBox.name = "Down";
            UpBox.SetActive(true);
            UpBox.transform.position = vector1;
        }
        else if (randomNumber == (int)MyEnum.RIGHT)
        {
            GameObject UpBox = Instantiate(Right);
            UpBox.name = "Right";
            UpBox.SetActive(true);
            UpBox.transform.position = vector1;
        }
        else if (randomNumber == (int)MyEnum.LEFT)
        {
            GameObject UpBox = Instantiate(Left);
            UpBox.name = "Left";
            UpBox.SetActive(true);
            UpBox.transform.position = vector1;
        }
    }
    IEnumerator spawnBlock()
    {
        for (int i = 0; i < maxArrow; i++)
        {
            yield return new WaitForSeconds(time);
            createObject();
        }
        yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(nextLevelID);
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        int boxId = checkName();

        if (Input.GetKey(KeyCode.DownArrow) && boxId == (int)MyEnum.DOWN)
        {
            Debug.Log("sa");
            sayac += 1;
            Destroy(gameObject);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && boxId == (int)MyEnum.UP)
        {
            Debug.Log("as");
            sayac += 1;
            Destroy(gameObject);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && boxId == (int)MyEnum.RIGHT)
        {
            Debug.Log("saa");
            sayac += 1;
            Destroy(gameObject);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && boxId == (int)MyEnum.LEFT)
        {
            Debug.Log("asa");
            sayac += 1;
            Destroy(gameObject);
        }
    }
    private int checkName()
    {
        if (gameObject.name.Equals("Up"))
        {
            return (int)(MyEnum.UP);
        }
        else if (gameObject.name.Equals("Down"))
        {
            return (int)(MyEnum.DOWN);
        }
        else if (gameObject.name.Equals("Right"))
        {
            return (int)(MyEnum.RIGHT);
        }
        else if (gameObject.name.Equals("Left"))
        {
            return (int)(MyEnum.LEFT);
        }
        return 0;
    }
    private int randomNumbers()
    {
        System.Random rnd = new System.Random();
        return rnd.Next(1, 5);
    }
}
