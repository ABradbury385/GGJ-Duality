using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] GameObject outStairs;

    public Vector2 OutStairLocation
    {
        get { return outStairs.transform.position; }
    }
}
