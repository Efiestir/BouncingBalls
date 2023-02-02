using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> bouncingCubeList;
    public GameObject bouncingCubePrefab, ballPrefab, pointCubePrefab, Camera;
    public int bouncingCubeCount, pointCubeCount;
    public Dictionary<int, (int, GameObject)> PointCubeCountDictionary = new Dictionary<int, (int, GameObject)>();
    
    void Awake()
    {
        AddPointCubeCounts(pointCubeCount);
    }
    void Start()
    {
        CreateBouncingCubes();
        CreateBall();
        CreatePointCubes();
    }

    public void CreateBouncingCubes()
    {
        for(int  i = 0 ; i < bouncingCubeCount ; i++)
        {
            Vector3 locationVector = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            bouncingCubeList.Add(Instantiate(bouncingCubePrefab, locationVector,Quaternion.identity));
        }
    }

    public void AddPointCubeCounts(int cubeCount)
    {
        for (int i = 0; i < 5; i++)
        {
            PointCubeCountDictionary.Add(((i+1)*10), (pointCubeCount, pointCubePrefab));
        }
    }

    public void CreateBall()
    {
        GameObject Ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        Ball.GetComponent<Rigidbody>().AddForce(0, 875, 0);
        Camera.transform.SetParent(Ball.transform);
    }

    public void CreatePointCubes()
    {
        foreach (KeyValuePair<int, (int, GameObject)> count in PointCubeCountDictionary)
        {
            for (int i = 0; i < count.Value.Item1; i++)
            {
                GameObject pointCube = Instantiate(count.Value.Item2,
                    new Vector3(Random.Range(-10, 10), Random.Range(count.Key - 5, count.Key + 5),
                        Random.Range(-10, 10)), Quaternion.identity);
                pointCube.GetComponent<PointCube>().SetLevelItems(count.Key);
            }
        }
    }

    public void CreatePointCube(int iban)
    {
        
    }
}
