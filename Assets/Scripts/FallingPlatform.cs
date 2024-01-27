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


    Vector2 xyPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xyPos = transform.position;
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Equals("Player"))
        {
            rb.isKinematic = false;
            Invoke("disableObject", DisableWaitSecond);

            Invoke("ActivateObject", ActiveWaitSecond);
        }
    }
    private void disableObject()
    {
        rb.gameObject.SetActive(false);
    }
    private void ActivateObject()
    {
        rb.gameObject.SetActive(true);
        Debug.Log(transform.localPosition);
        Debug.Log(xyPos);
        if (transform.position.y >= xyPos.y)
        {

            rb.velocity = new Vector2(0f, 0f);
            rb.isKinematic = true;
            //transform.position = xyPos;
        }
        else
        {
            rb.gravityScale = -1;
            rb.velocity = new Vector2(xyPos.x, 1);
            //rb.velocity = new Vector2(0f, 0f);
            Invoke("wait", 0.95f);
            Debug.Log("seai");
        }
    }
    private void wait()
    {
        rb.bodyType = RigidbodyType2D.Static;
        rb.gravityScale = 1;
        transform.position = xyPos;
    }
}
