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
            pos.z = 10;

            Instantiate(tile, cam.ScreenToWorldPoint(pos), Quaternion.identity);
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
}
