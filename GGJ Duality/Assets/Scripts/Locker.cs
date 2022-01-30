using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Togglable
{
    private bool isOpen;
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openSprite;
        isOpen = true;
    }

    public override void Toggle()
    {
        if(isOpen)
        {
            isOpen = false;
            spriteRenderer.sprite = closedSprite;
        }
        else
        {
            isOpen = true;
            spriteRenderer.sprite = openSprite;
        }
    }
}
