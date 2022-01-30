using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [SerializeField] bool isScared;
    [SerializeField] int moveSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 direction;
    private float moveValue;

    public bool IsScared
    {
        get { return isScared; }
        set { isScared = value; }
    }

    public float MoveValue { get { return moveValue; } set { moveValue = value; } }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Look X", direction.x);
        animator.SetFloat("Speed", Mathf.Abs(moveValue));
    }

    public void MoveToPosition(Vector2 _pos)
    {
        rb.position = Vector2.MoveTowards(transform.position, _pos, moveSpeed * Time.deltaTime);
        direction = _pos - (Vector2)transform.position;
        moveValue = moveSpeed * direction.x;
    }
}
