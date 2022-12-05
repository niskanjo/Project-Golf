using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            float XCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float YCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            Debug.Log("Left mouse button pressed at x = " + XCoordinate + ", y = " + YCoordinate);
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            float XCoordinate = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float YCoordinate = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
            Debug.Log("Left mouse button released at x = " + XCoordinate + ", y = " + YCoordinate);
        }
    }
}
