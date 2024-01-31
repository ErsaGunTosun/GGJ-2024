using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    [SerializeField] private float ActiveWaitSecond = 1.6f;
    [SerializeField] private float DisableWaitSecond = 0.7f;

    [SerializeField] private Rigidbody2D rb;

    Vector2 xyPos;

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gameObject.SetActive(true);
        xyPos = transform.position;
    }

    public void OnTriggerEnter2D()
    {
        Debug.Log("SEA");
        if (gameObject.tag == "Player")
        {
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
    }
}


        /*IEnumerator DisableObject()
        {
            rb.isKinematic = false;
            yield return new WaitForSeconds(DisableWaitSecond);
            //rb.gameObject.SetActive(false);

        }
        IEnumerator ActiveObject()
        {
            if (transform.position.y >= xyPos.y)
            {

                //rb.velocity = new Vector2(0f, 0f);
                rb.isKinematic = true;
                //transform.position = xyPos;
            }
            else
            {
                rb.gravityScale = -1;
                rb.velocity = new Vector2(xyPos.x, 1);
                rb.velocity = new Vector2(0f, 0f);
                //Invoke("wait", 0.95f);
                Debug.Log("seai");
            }
            yield return new WaitForSeconds(ActiveWaitSecond);
            rb.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.95f);
            rb.bodyType = RigidbodyType2D.Static;
            rb.gravityScale = 1;
            transform.position = xyPos;
        }*/


