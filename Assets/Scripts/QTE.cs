using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QTE : MonoBehaviour
{
    /*
    public Transform arrowSpawnPoint;  // Oklar�n ba�lang�� konumu
    public GameObject arrowPrefab;     // Ok objesi

    private GameObject currentArrow;   // Mevcut ok objesi
    private KeyCode requiredKey;       // Gerekli tu�

    void Start()
    {
        SpawnArrow();
    }

    void Update()
    {
        if (Input.GetKeyDown(requiredKey))
        {
            Debug.Log("Do�ru tu�a bas�ld�!");
            Destroy(currentArrow);
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        requiredKey = GetRandomArrowKey();
    }

    KeyCode GetRandomArrowKey()
    {
        KeyCode[] arrowKeys = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };
        return arrowKeys[Random.Range(0, arrowKeys.Length)];
    }
    */
}