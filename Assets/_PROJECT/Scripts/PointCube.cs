using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCube : MonoBehaviour
{
    [HideInInspector] public int point;
    public PointCubeLevels pointCubeLevel;
    public List<Material> materialList;
    public void SetLevelItems(int level)
    {
        switch (level)
        {
            case 10:
                pointCubeLevel = PointCubeLevels.One;
                GetComponent<MeshRenderer>().material = materialList[0];
                point = 1;
                break;
            case 20:
                pointCubeLevel = PointCubeLevels.Two;
                GetComponent<MeshRenderer>().material = materialList[1];
                point = 2;
                break;
            case 30:
                pointCubeLevel = PointCubeLevels.Three;
                GetComponent<MeshRenderer>().material = materialList[2];
                point = 3;
                break;
            case 40: 
                pointCubeLevel = PointCubeLevels.Four;
                GetComponent<MeshRenderer>().material = materialList[3];
                point = 4;
                break;
            case 50:
                pointCubeLevel = PointCubeLevels.Five;
                GetComponent<MeshRenderer>().material = materialList[4];
                point = 5;
                break;
        }
    }
}

public enum PointCubeLevels
{
    One = 10, Two = 20 , Three = 30, Four = 40, Five = 50
}
