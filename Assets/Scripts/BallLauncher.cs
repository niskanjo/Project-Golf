using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallLauncher : MonoBehaviour
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public Vector2 Direction;
    Rigidbody2D Physics;
    GameObject Ball;
    float force = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Physics = GetComponent<Rigidbody2D>();
        Ball = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true )
        {
            StartPosition = Input.mousePosition;
            Debug.Log("Left mouse button pressed at " + StartPosition);

        }
        if (Input.GetMouseButtonUp(0) == true /*&& Vector2.Distance(StartPosition, Ball.transform.position) < 0.5*/)
        {
            EndPosition = Input.mousePosition;
            Debug.Log("Left mouse button released at " + EndPosition);
            Direction = (StartPosition - EndPosition);
            Physics.AddForce(Direction * force);

        }

        
        //Debug.Log("Force: " + force);

        if (transform.position.x < -10 || transform.position.x > 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
