using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] int doorNumber;

    public int DoorNumber
    {
        get { return doorNumber; }
    }
}
