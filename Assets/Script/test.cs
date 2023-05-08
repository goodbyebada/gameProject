using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
    public float speed = 5f; // The speed in m/s

    private Tilemap tilemap;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    //private float t;


    void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        targetPosition = GetRandomTilePosition();
        startPosition = transform.position;
        //t = 0f;
    }

    void Update()
    {
        //t += Time.deltaTime * speed / Vector3.Distance(startPosition, targetPosition);

        //if (t >= 1.0f)
        //{
            //t = 0f;
            startPosition = transform.position;
            targetPosition = GetRandomTilePosition();
        //}

        transform.position = Vector3.MoveTowards(startPosition, targetPosition,
            speed*Time.deltaTime);
    }

    private Vector3 GetRandomTilePosition()
    {
        Vector3Int randomTilePosition = new Vector3Int(Random.Range(tilemap.cellBounds.min.x, tilemap.cellBounds.max.x),
                                                      Random.Range(tilemap.cellBounds.min.y, tilemap.cellBounds.max.y),
                                                      0);
        Vector3 tileCenter = tilemap.CellToWorld(randomTilePosition);
        return tileCenter;
    }
}
