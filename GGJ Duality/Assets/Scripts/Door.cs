using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Togglable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Toggle()
    {
        if (isOpen)
        {
            isOpen = false;
            spriteRenderer.color = new Color(0.47f, 0.25f, 0);
            gameObject.layer = 0;
        }
        else
        {
            isOpen = true;
            spriteRenderer.color = new Color(0.47f, 0.25f, 0, 0.5f);
            gameObject.layer = 1;
        }
    }
}
