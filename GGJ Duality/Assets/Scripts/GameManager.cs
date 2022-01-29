using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool hasKey;
    [SerializeField] private bool victory;
    [SerializeField] private List<Student> enemyList;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject girl;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;


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
            //UpdateEnemies();

            if (Input.GetMouseButtonDown(0))
            {
                CheckClickGirl();
            }

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                CheckStairs();
            }
        }
    }

    private void FixedUpdate()
    {
        UpdateEnemies();
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
    private void CheckClickGirl()
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

            if (target.gameObject.name == "Key")
            {
                if (Vector2.Distance(girl.transform.position, target.transform.position) <= 1)
                {
                    Destroy(target);
                    hasKey = true;
                }
            }

            if (target.gameObject.name == "LockedDoor")
            {
                if (Vector2.Distance(girl.transform.position, target.transform.position) <= 1)
                {
                    if (hasKey)
                    {
                        Destroy(target);
                    }
                }
            }
        }
    }

    // Checks if a character tried to use the stairs
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

    private void UpdateEnemies()
    {
        foreach(Student enemy in enemyList)
        {
            // If the ghost is nearby, scare the student
            if(!enemy.IsScared && Vector2.Distance(ghost.transform.position, enemy.transform.position) <= 2)
            {
                Debug.Log("Ghost nearby...");
                enemy.IsScared = true;
                enemy.gameObject.layer = 1;
            }

            // If the student is not scared and there is a clear path to the girl, chase the girl.
            if(!enemy.IsScared)
            {
                Debug.Log("Searching...");

                Vector2 ray = girl.transform.position - enemy.transform.position;
                ray.y = 0;
                RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, ray, 10, mask);
                Debug.DrawRay(enemy.transform.position, ray);

                if(hit)
                {
                    Debug.Log(hit.collider.gameObject);

                    if (hit.collider.gameObject.tag == "Player")
                    {
                        Debug.Log("Chasing the girl...");
                        enemy.MoveToPosition(girl.transform.position);
                    }
                }
            }

            // If the ghost left, unscare the student
            if(enemy.IsScared && Vector2.Distance(ghost.transform.position, enemy.transform.position) > 2)
            {

                Debug.Log("Ghost left...");
                enemy.IsScared = false;
                enemy.gameObject.layer = 8;
            }
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
