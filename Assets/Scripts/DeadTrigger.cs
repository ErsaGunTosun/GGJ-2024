using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    GameObject player;
    Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.position = SpawnPoint.position;
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
        
    }
}
