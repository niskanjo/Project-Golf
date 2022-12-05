using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Vector2 Force;
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    Rigidbody2D Physics;

    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) == true)
        {
            StartPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            StartPosition.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            Debug.Log("Left mouse button pressed at x = " + StartPosition.x + ", y = " + StartPosition.y);

        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            EndPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            EndPosition.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            Debug.Log("Left mouse button released at x = " + EndPosition.x + ", y = " + EndPosition.y);

        }
    }

    public void Launcher()
    {

    }
}
