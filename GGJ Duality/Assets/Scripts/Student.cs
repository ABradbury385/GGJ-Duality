using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] bool isScared;
    [SerializeField] int moveSpeed;
    private Rigidbody2D rb;

    public bool IsScared
    {
        get { return isScared; }
        set { isScared = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPosition(Vector2 _pos)
    {
        rb.position = Vector2.MoveTowards(transform.position, _pos, moveSpeed * Time.deltaTime);
    }
}
