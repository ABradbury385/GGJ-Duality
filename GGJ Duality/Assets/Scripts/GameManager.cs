using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool hasKey;
    [SerializeField] private bool victory;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<Door> doorList;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject girl;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!victory)
        {
            // Update all enemies
            // Update all doors

        }

        if(Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            CheckStairs();
        }
    }

    private void CheckVictory()
    {
        if(Vector2.Distance(girl.transform.position, goal.transform.position) <= 1
            && Vector2.Distance(ghost.transform.position, goal.transform.position) <= 1)
        {
            victory = true;
        }
    }

    // Checks if the mouse click hits a toggleable object. If it does, checks if the girl is nearby.
    //      If both are true, tries to toggle the object.
    private void CheckClick()
    {
        Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if(hit)
        {
            target = hit.collider.gameObject;
            Debug.Log("Hit a target...");

            // Toggleable
            if (target.TryGetComponent<Togglable>(out Togglable toggleable))
            {
                Debug.Log("Target is a togglable...");
                Debug.Log(Vector2.Distance(girl.transform.position, toggleable.transform.position));
                if (Vector2.Distance(girl.transform.position, toggleable.transform.position) <= 1)
                {
                    Debug.Log("Trying to toggle object...");
                    toggleable.Toggle();
                }
            }
        }
    }

    private void CheckStairs()
    {
        Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if (hit)
        {
            target = hit.collider.gameObject;

            if(target.TryGetComponent<Stairs>(out Stairs stairs))
            {
                // Girl use stairs
                if(Input.GetMouseButtonDown(0))
                {
                    if (Vector2.Distance(girl.transform.position, stairs.transform.position) <= 1)
                    {
                        girl.transform.position = stairs.OutStairLocation;
                    }
                }

                // Ghost use stairs
                if (Input.GetMouseButtonDown(1))
                {
                    if (Vector2.Distance(ghost.transform.position, stairs.transform.position) <= 1)
                    {
                        ghost.transform.position = stairs.OutStairLocation;
                    }
                }
            }
        }
    }
}
