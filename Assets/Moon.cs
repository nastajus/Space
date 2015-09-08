using UnityEngine;
using System.Collections;

public class Moon : Stats {

    private GameObject earth;
    private GameObject moon;
    private float angle;

	// Use this for initialization
	void Start () {
        earth = GameObject.Find("Earth");
        if (earth == null) Debug.LogWarning("Earth is missing! Check the Medusa Cascade, an inter-universal rift!");
        moon = gameObject; //just for readability
	}
	
	// Update is called once per frame
	void Update () {
        if (earth == null) return;

        //move on circular path relative to earth
        Vector3 dir = (earth.transform.position - moon.transform.position).normalized;
        float dist = Vector3.Distance(earth.transform.position, moon.transform.position);
        Vector3 pos = moon.transform.position;
        Debug.DrawRay(pos, dir * dist, Color.yellow);

        Vector3 perp = Vector3.Cross(moon.transform.forward, dir);
        Debug.DrawRay(pos, perp * dist, Color.blue);

        //angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
       // Debug.Log(angle);
        //TOA
        float x = dist * Mathf.Cos((Mathf.Deg2Rad * angle));
        float y = dist * Mathf.Sin((Mathf.Deg2Rad * angle));
        //Debug.Log((Mathf.Deg2Rad * angle));
        moon.transform.position = new Vector3(x,y,moon.transform.position.z);
        float keys = Input.GetAxis("Horizontal");
        if(keys != 0){
            angle = (angle - 1 * keys )%360;
        }
        //Debug.Log(angle);
        //transform.Translate();
	}
}
