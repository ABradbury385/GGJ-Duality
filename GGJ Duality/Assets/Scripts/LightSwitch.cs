using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Togglable
{
    [SerializeField] private GameObject lightArea;
    [SerializeField] private bool toggled;

    // Start is called before the first frame update
    void Start()
    {
        if(toggled)
        {
            lightArea.SetActive(true);
        }
        else
        {
            lightArea.SetActive(false);
        }
    }


    public override void Toggle()
    {
        if(toggled)
        {
            toggled = false;
            lightArea.SetActive(false);
        }
        else
        {
            toggled = true;
            lightArea.SetActive(true);
        }
    }
}
