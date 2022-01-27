using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Variables
    [SerializeField] Camera cam;
    GameObject target;
    [SerializeField] GameObject tile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CheckMouseTarget();
        }

        if (Input.GetMouseButtonDown(0))
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

    private void CheckMouseTarget()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            target = hit.transform.gameObject;

            if(target.tag == "Tile")
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
