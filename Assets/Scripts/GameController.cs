using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Vector2 xyPos;
    bool isDie = false;

    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xyPos = transform.position;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            isDie = true;
            
            if(isDie)
            {
                rb.gameObject.SetActive(!isDie);
                Invoke("Die", 1f);
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }*/


    private void Die()
    {
        isDie = true;
        rb.gameObject.SetActive(isDie);
        Respawn();
    }
    private void Respawn()
    {
        transform.position = xyPos;
    }

}
