using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoads : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    public float RoadWorks = 0;
    public float Length = 84.5f;
    public float NextRoad = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTile(0);
        spawnTile(1);
        spawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnTile(int i)
    {
        
        Instantiate(roadPrefabs[i], new Vector3(0,0,NextRoad), Quaternion.Euler(0,90,0));
        NextRoad += Length;
    }
}
