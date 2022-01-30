using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<int> keysAquired;
    [SerializeField] private bool victory;
    [SerializeField] private List<Student> enemyList;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject girl;
    private bool isGirlInLocker;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        victory = false;

        girlSpriteRenderer = girl.GetComponent<SpriteRenderer>();
        girlRB = girl.GetComponent<Rigidbody2D>();
        girlBoxCollider = girl.GetComponent<BoxCollider2D>();
        girlMovement = girl.GetComponent<CharacterMovement>();
        isGirlInLocker = false;
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
        if(enemyList.Count > 0)
        {
            UpdateEnemies();
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
    private void CheckClickGirl()
    {
        Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if(hit)
        {
            target = hit.collider.gameObject;

            // Toggleable
            if (target.TryGetComponent<Togglable>(out Togglable toggleable))
            {
                Debug.Log(Vector2.Distance(girl.transform.position, toggleable.transform.position));
                if (Vector2.Distance(girl.transform.position, toggleable.transform.position) <= 1)
                {
                    toggleable.Toggle();

                    // Locker
                    if(toggleable.gameObject.name == "Locker")
                    {
                        if(!isGirlInLocker)
                        {
                            girl.SetActive(false);
                            isGirlInLocker = true;
                        }
                        else
                        {
                            Debug.Log("Girl out of locker");
                            girl.SetActive(true);
                            isGirlInLocker = false;
                        }
                    }
                }
            }

            if (target.TryGetComponent<Key>(out Key key))
            {
                if (Vector2.Distance(girl.transform.position, key.transform.position) <= 1)
                {
                    keysAquired.Add(key.KeyNumber);
                    Destroy(target);
                }
            }

            if (target.TryGetComponent<LockedDoor>(out LockedDoor door))
            {
                if (Vector2.Distance(girl.transform.position, door.transform.position) <= 1)
                {
                    if (keysAquired.Contains(door.DoorNumber))
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
                enemy.IsScared = true;
                enemy.gameObject.layer = 1;
            }

            // If the student is not scared and there is a clear path to the girl, chase the girl.
            if(!enemy.IsScared)
            {
                Vector2 ray = girl.transform.position - enemy.transform.position;
                ray.y = 0;
                RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, ray, 10, mask);
                Debug.DrawRay(enemy.transform.position, ray);

                if(hit)
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        enemy.MoveToPosition(girl.transform.position);
                    }
                }
            }

            // If the ghost left, unscare the student
            if(enemy.IsScared && Vector2.Distance(ghost.transform.position, enemy.transform.position) > 2)
            {
                enemy.IsScared = false;
                enemy.gameObject.layer = 8;
            }
        }
    }
}
