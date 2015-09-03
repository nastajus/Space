using UnityEngine;
using System.Collections.Generic;

public class Orbit : MonoBehaviour {
    
    GameObject moonTest;
    float mass;
    //F=ma

	// Use this for initialization
	void Start () {
        FindGravitatable();
        AddTrailRenderer(moonTest);
        AddRigidbody(moonTest);
        AddRigidbody(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        mass = gameObject.GetComponent<Rigidbody>().mass;
        FindGravitatable();
        PullGravitatables();
    }

    //find objects to pull into gravitation well
    void FindGravitatable()
    {
        //List<Test> test = GameObject.FindObjectsOfType<Test>();
        moonTest = GameObject.Find("Moon");
        if (moonTest == null) return;
    }

    void PullGravitatables()
    {
        //unsafe unchecked
        float dist = Vector3.Distance(moonTest.transform.position, transform.position);
        Vector3 dir = transform.position - moonTest.transform.position;
        moonTest.GetComponent<Rigidbody>().AddForce(dir * mass);
        Color col = new Color(1 / dist, 0f, 0f);
        Debug.DrawRay(moonTest.transform.position, dir, col);
        PushPerp(dir, dist);

    }

    void PushPerp(Vector3 dir, float dist)
    {
        //push perpendicular to line between other object and this object
        //"Take cross product with any vector. You will get one such vector."
        //public static Vector3 Cross(Vector3 lhs, Vector3 rhs);    
        Vector3 perp = Vector3.Cross(dir, Vector3.forward);
        Color col = new Color(0f, 1 / dist, 0f);
        Debug.DrawRay(moonTest.transform.position, perp, col);
        moonTest.GetComponent<Rigidbody>().AddForce(perp * mass * 3f);

    }

    void AddRigidbody(GameObject gameObject)
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    void AddTrailRenderer(GameObject gameObject)
    {
        if (gameObject.GetComponent<TrailRenderer>() == null)
        {
            TrailRenderer tr = gameObject.AddComponent<TrailRenderer>();
            tr.material.color = new Color(0f,0f,1f);
        }

    }
}
