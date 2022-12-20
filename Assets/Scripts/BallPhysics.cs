using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallPhysics : MonoBehaviour
{
    public Vector2 StartPosition;   // Define start position for launch vector
    public Vector2 EndPosition;     // Define end position for launch vector
    public Vector2 MousePosition;   // Define mouse position
    public Vector2 Direction;       // Define launch direction
    public Vector2 AxisReference;   // Reference point for X axis
    public Vector2 HorizontalAxis;  // X axis relative to ball
    public Vector2 BallPosition;    // Ball position
    public Vector2 LaunchVector;    // Launch vector
    public Vector2 Wind;            // Vector for wind effect

    Rigidbody2D Physics;

    public TMPro.TMP_Text UIAngle;
    public TMPro.TMP_Text UIForce;
    public TMPro.TMP_Text UIHitCount;
    public TMPro.TMP_Text UIWind;

    string angleOut;
    string forceOut;

    bool startPosLogged;
    int hitCount;

    float angle;
    float clubMass = 80f;   // Mass of hypothetical golf club

    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();

        hitCount = 0;

        startPosLogged = false;
    }

    // Update is called once per frame
    void Update()
    {
        Launch();
        DebugControl();

        Physics.AddForce(Wind);

        if (transform.position.x < -11 || transform.position.x > 11)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Launch()
    {
        if (Physics.velocity.magnitude < 0.5)
        {
            if (Input.GetMouseButtonDown(0) == true && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1)
            {
                RandomizeWind();
                StartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("Left mouse button pressed at " + StartPosition);
                Debug.Log("Distance from mousePosition to ball: " + Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position));
                startPosLogged = true;

                AxisReference.y = transform.position.y;
                AxisReference.x = transform.position.x + 1;
                BallPosition = transform.position;  // Convert transform.position to Vector2



            }
        }


        // Axis and force UI output handler
        if (Input.GetMouseButton(0))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Direction = StartPosition - MousePosition;

            HorizontalAxis = AxisReference - BallPosition;  // X axis relative to ball
            angle = Vector2.Angle(Direction, HorizontalAxis);   // Angle between mouse drag vector and X axis relative to ball

            angleOut = Math.Floor(angle) + "\u02DA";
            forceOut = Math.Floor(Vector2.Distance(StartPosition, MousePosition)) + "N";
        }


        UIAngle.text = "Angle: " + angleOut;
        UIForce.text = "Force: " + forceOut;



        if (Input.GetMouseButtonUp(0) == true && startPosLogged == true)
        {
            EndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Left mouse button released at " + EndPosition);
            Direction = StartPosition - EndPosition;
            LaunchVector = Direction * clubMass;
            Physics.AddForce(LaunchVector);


            Debug.Log("Launch vector: " + LaunchVector);
            Debug.Log("Launch force: " + Vector2.Distance(StartPosition, EndPosition));
            Debug.Log("Launch angle: " + angle);

            startPosLogged = false;
            hitCount++;
        }

        UIHitCount.text = "Hits: " + hitCount;
    }

    private void DebugControl()
    {
        if (Input.GetKeyDown("space"))  // Stop ball movement
        {
            Physics.velocity = Vector2.zero;
            Debug.Log("Debug: Ball forced to stop");
        }
    }
    public void RandomizeWind()
    {
        Wind.x = UnityEngine.Random.Range(-0.5f, 0.5f);
        if (Wind.x < 0)
        {
            Debug.Log("Wind Direction: West");
            UIWind.text = "Wind: " + (Wind.x * 10 * -1);
        }
        else if (Wind.x < 0)
        {
            Debug.Log("Wind Direction: East");
            UIWind.text = "Wind: " + (Wind.x * 10);
        }
    }
}
