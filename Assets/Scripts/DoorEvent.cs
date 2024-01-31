using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    public GameObject Door;
    public bool isTouchDoor = false;

    // Start is called before the first frame update
    void Start()
    {
       Door = GameObject.FindGameObjectWithTag("Door");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Door == null)
        {
            Debug.LogWarning("ADAM KAPIYI SÖKTÜ GÖTÜRÜYOR");
        }
        else
        {

            isTouchDoor = true;
            Door.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }


}
