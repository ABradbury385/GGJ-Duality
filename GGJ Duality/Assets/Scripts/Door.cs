using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Togglable
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void Toggle()
    {
        if (isOpen)
        {
            isOpen = false;
            spriteRenderer.color = Color.white;
            boxCollider.enabled = true;
        }
        else
        {
            isOpen = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            boxCollider.enabled = false;
        }
    }
}
