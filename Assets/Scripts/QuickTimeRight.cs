using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

enum MyEnum
{
    UP =  1,
    DOWN = 2,
    RIGHT = 3,
    LEFT = 4
}

public class QuickTime : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] Rigidbody2D rb;

    public GameObject Up;
    public GameObject Down;
    public GameObject Right;
    public GameObject Left;

    private bool isTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(speed,rb.velocity.y);
        checkName();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        int boxId =  checkName();
        if (Input.GetKey(KeyCode.DownArrow) &&  boxId == (int)MyEnum.DOWN)
        {
            Debug.Log("Down");
            Destroy(gameObject);
            isTrigger = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && boxId == (int)MyEnum.UP){

            Debug.Log("Up");
            Destroy(gameObject);
            isTrigger = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && boxId == (int)MyEnum.RIGHT)
        {
            Debug.Log("Right");
            Destroy(gameObject);
            isTrigger = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && boxId == (int) MyEnum.LEFT)
        {
            Debug.Log("Left");
            Destroy(gameObject);
            isTrigger = true;
        }
        if (isTrigger) {
            randomNumber();
        };
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
    private void randomNumber()
    {
        Vector2 vector1 = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);

        System.Random rnd = new System.Random();

        int randomNumber = rnd.Next(1, 5);

        if(randomNumber == (int)MyEnum.UP)
        {
            GameObject UpBox = Instantiate(Up); 
            UpBox.transform.position = vector1;
        }
        else if (randomNumber == (int)MyEnum.DOWN)
        {
            GameObject DownBox = Instantiate(Down);
            DownBox.transform.position = vector1;
        }
        else if(randomNumber == (int)MyEnum.RIGHT)
        {
            GameObject RightBox = Instantiate(Right);
            RightBox.transform.position = vector1;
        }
        else if (randomNumber == (int)MyEnum.LEFT)
        {
            GameObject LeftBox = Instantiate(Left);
            LeftBox.transform.position = vector1;
        }

        Debug.Log(rnd);
    }

    private GameObject Instantiate(GameObject up, Vector2 vector1)
    {
        throw new NotImplementedException();
    }
}
