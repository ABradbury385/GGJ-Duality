using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] int keyNumber;

    public int KeyNumber
    {
        get { return keyNumber; }
    }
}
