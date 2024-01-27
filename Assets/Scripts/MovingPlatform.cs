using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    [SerializeField] private float platformDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance( WayPoints[currentWaypointIndex].transform.position,transform.position) < platformDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= WayPoints.Length)
                currentWaypointIndex = 0;

        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[currentWaypointIndex].transform.position,Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
