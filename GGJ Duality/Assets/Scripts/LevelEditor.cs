using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Variables
    [SerializeField] Camera cam;
    GameObject target;
    [SerializeField] GameObject tile;
    [SerializeField] GameObject leftPlayer;
    [SerializeField] GameObject rightPlayer;

    Vector2 leftStart;
    Vector2 rightStart;

    // Start is called before the first frame update
    void Start()
    {
        leftStart = leftPlayer.transform.position;
        rightStart = rightPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            leftPlayer.transform.position = leftStart;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            rightPlayer.transform.position = rightStart;
        }

        // Delete
        if (Input.GetMouseButtonDown(1))
        {
            CheckMouseTarget();
        }

        // Place
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (!hit)
            {
                Vector3 pos = Input.mousePosition;


                pos = cam.ScreenToWorldPoint(pos);

                Debug.Log("Click: " + pos);

                pos.x = RoundPosition(pos.x);
                pos.y = RoundPosition(pos.y);

                pos.z = 10;

                Debug.Log("Spawn: " + pos);
                Instantiate(tile, pos, Quaternion.identity);
            }

        }
    }

    private void CheckMouseTarget()
    {
        Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

        if(hit)
        {
            target = hit.collider.gameObject;

            if (target.tag == "Tile")
            {
                Destroy(target);
            }
        }

    }

    private float RoundPosition(float _pos)
    {
        _pos = Mathf.Floor(_pos / 0.5f);
        _pos = (_pos * 0.5f) + 0.25f;

        /*        // round down
                if((_pos % 1) < 0.5f)
                {
                    _pos = Mathf.Floor(_pos / 0.5f);
                    _pos = _pos * 0.5f;
                }
                // round up
                else
                {
                    _pos = Mathf.Ceil(_pos / 0.5f);
                    _pos = _pos * 0.5f;
                }*/

        return _pos;
    }
}
