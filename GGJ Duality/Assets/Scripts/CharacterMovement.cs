using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    private float moveSpeed = 20.0f;
    [SerializeField]
    [Range(0,2)]
    private int movementMouseClick;

    private float horizontalMovement;
    private Vector2 direction;
    private Vector3 mousePos;
    private Vector2 targetPos;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        targetPos = transform.position;
        Physics.IgnoreLayerCollision(1, 8);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0.0f)
        {
            targetPos = transform.position;
        }

        if (Input.GetMouseButtonDown(movementMouseClick))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector2(mousePos.x, transform.position.y);
            direction = ((Vector2)transform.position - targetPos).normalized;
            horizontalMovement = moveSpeed;
        }

        animator.SetFloat("Look X", direction.x);
        animator.SetFloat("Speed", rb.velocity.x);
    }

    private void FixedUpdate()
    {
        //move to clicked position
        float step = moveSpeed * Time.deltaTime;
        rb.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.x, transform.position.y), step);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, direction - (Vector2)transform.position);
    }

    //Detect when there is a collision
    void OnCollisionStay(Collision collide)
    {
        //Output the name of the GameObject you collide with
        Debug.Log("I hit the GameObject : " + collide.gameObject.name);
    }
}
