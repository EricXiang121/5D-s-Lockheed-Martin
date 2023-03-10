using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaypointPath2 : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    public float moveSpeed = 2f;
    public int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints [waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == waypoints.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
