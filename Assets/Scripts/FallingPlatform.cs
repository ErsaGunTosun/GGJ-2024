using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField] private float ActiveWaitSecond = 1.6f;
    [SerializeField] private float DisableWaitSecond= 0.7f;

    [SerializeField] private Rigidbody2D rb;



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("disableObject", DisableWaitSecond);


            Invoke("ActivateObject", ActiveWaitSecond);


        }
    }
    private void disableObject()
    {
        rb.gameObject.SetActive(false);
    }
    public void ActivateObject()
    {
        rb.gameObject.SetActive(true);
    }
}
