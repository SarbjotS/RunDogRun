using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoads : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float RoadWorks = 0;
    public float Length = 67.5f;
    public float NextRoad = 0;
    public int num = 2;
    public Transform playT;
    private int nextRoad = 65;
    private List<GameObject> RoadPieces = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i< num; i++)
        {
            spawnTile(Random.Range(0, roadPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playT.position.z>nextRoad)
        {
            spawnTile(Random.Range(0, roadPrefabs.Length));
            nextRoad += 65;
            RemoveLastRoadPiece();
        }
    }
    public void spawnTile(int i)
    {
        
        GameObject obj = Instantiate(roadPrefabs[i], new Vector3(0,0,NextRoad), Quaternion.Euler(0,90,0));
        RoadPieces.Add(obj);
        NextRoad += Length;
    }

    public void RemoveLastRoadPiece()
    {
        Destroy(RoadPieces[0]);
        RoadPieces.RemoveAt(0);
        
    }
}
