using UnityEngine;
using System.Collections;

public class Moon : Logger {

    private static GameObject earth;
    private static GameObject moon;
    private static float angle;

	// Use this for initialization
	void Start () {
        earth = GameObject.Find("Earth");
        if (earth == null) Debug.LogWarning("Earth is missing! Check the Medusa Cascade, an inter-universal rift!");
        moon = gameObject; //just for readability
        
        angle = 180 + FindAngle(moon.transform.position, earth.transform.position);
        Log("Moon angle: " + angle + "(start)");

	}
	
	// Update is called once per frame
	void Update () {
        if (earth == null) return;
        float moveDir = Input.GetAxis("Horizontal");
        Move(moveDir);
	}

    // Move moon on circular path relative to earth.
    // Note this doesn't obey physics, it's a fake orbit.
    // When moveDir is -1, it means left when moon is above earth. +1 is right.
    public static void Move(float moveDir)
    {
        Vector3 dir = (earth.transform.position - moon.transform.position).normalized;
        float dist = Vector3.Distance(earth.transform.position, moon.transform.position);
        Vector3 pos = moon.transform.position;
        Debug.DrawRay(pos, dir * dist, Color.yellow);

        Vector3 perp = Vector3.Cross(moon.transform.forward, dir);
        Debug.DrawRay(pos, perp * dist, Color.blue);

        //TOA
        float x = dist * Mathf.Cos((Mathf.Deg2Rad * angle));
        float y = dist * Mathf.Sin((Mathf.Deg2Rad * angle));
        moon.transform.position = new Vector3(x, y, moon.transform.position.z);
        if (moveDir != 0)
        {
            float nextAngle = (angle - 1 * moveDir) % 360;

            //wraps in underneath from left side
            angle = nextAngle;
            //Log(angle);
        }
    }

    private float FindAngle(Vector3 p1, Vector3 p2){
        //First find the difference between the start point and the end point.
        //deltaY = P2_y - P1_y
        //deltaX = P2_x - P1_x
        Vector3 delta = (p2 - p1);

        //Then calculate the angle.
        //angle = arctan(deltaY / deltaX) * 180 / PI
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        return angle ;
    }
}
