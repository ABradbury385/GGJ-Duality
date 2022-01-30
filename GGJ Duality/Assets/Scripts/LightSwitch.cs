using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Togglable
{
    [SerializeField] private GameObject lightArea;
    [SerializeField] private GameObject darkArea;
    [SerializeField] private bool toggled;

    // Start is called before the first frame update
    void Start()
    {
        if(toggled)
        {
            lightArea.SetActive(true);

            if (darkArea != null)
            {
                darkArea.SetActive(false);
            }
        }
        else
        {
            lightArea.SetActive(false);

            if (darkArea != null)
            {
                darkArea.SetActive(true);
            }
        }
    }


    public override void Toggle()
    {
        if(toggled)
        {
            toggled = false;
            lightArea.SetActive(false);

            if (darkArea != null)
            {
                darkArea.SetActive(true);
            }
        }
        else
        {
            toggled = true;
            lightArea.SetActive(true);

            if (darkArea != null)
            {
                darkArea.SetActive(false);
            }
        }
    }
}
