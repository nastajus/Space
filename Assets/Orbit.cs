using UnityEngine;
using System.Collections.Generic;

public class Orbit : MonoBehaviour {
    
    GameObject moonTest;
    float mass;
    Rigidbody rb;
    //F=ma
    float gravityCon = 20f;

	// Use this for initialization
	void Start () {
        FindGravitatable();
        AddTrailRenderer(moonTest);
        AddRigidbody(moonTest);
        AddRigidbody(gameObject);
        rb.mass = 30f;
        PushPerp();
    }
	
	// Update is called once per frame
	void Update () {
        mass = gameObject.GetComponent<Rigidbody>().mass;
        FindGravitatable();
        PullGravitatables();
        //Debug.Log("vel:" + moonTest.GetComponent<Rigidbody>().velocity);        
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
        Vector3 dir = (transform.position - moonTest.transform.position).normalized;
        moonTest.GetComponent<Rigidbody>().AddForce(gravityCon * mass / (dist * dist) * dir);
        //F = ma 
        //F = G(m1*m2)/r^2
        Color col = new Color(1 / dist, 0f, 0f);

        Debug.DrawRay(moonTest.transform.position, dir, col);
        //PushPerp(dir, dist);
        PushPerp();
    }

    //void PushPerp(Vector3 dir, float dist)
    void PushPerp()
    {
        //push perpendicular to line between other object and this object
        //"Take cross product with any vector. You will get one such vector."
        //public static Vector3 Cross(Vector3 lhs, Vector3 rhs);    

        float dist = Vector3.Distance(moonTest.transform.position, transform.position);
        Vector3 dir = transform.position - moonTest.transform.position;
        Vector3 perp = Vector3.Cross(dir, Vector3.forward).normalized;
        //Debug.Log(dir + ": " + perp);
        Color col = new Color(0f, 1 / dist, 0f);
        Debug.DrawRay(moonTest.transform.position, perp, col);
        moonTest.GetComponent<Rigidbody>().velocity = (perp * Mathf.Sqrt(gravityCon * mass / dist));
    }

    void AddRigidbody(GameObject gameObject)
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
    }

    void AddTrailRenderer(GameObject gameObject)
    {
        if (gameObject.GetComponent<TrailRenderer>() == null)
        {
            TrailRenderer tr = gameObject.AddComponent<TrailRenderer>();
            tr.time = 15f;
            tr.startWidth = 0.2f;
            tr.endWidth = 0.1f;
            //tr.material = Resources.Load<Material>("Materials/Test");
            //tr.material.color = new Color(0f,0f,1f);
            //tr.material.SetColor(0, new Color(0f, 0f, 1f));
            //print(tr.material.GetInstanceID());
            tr.materials[0] = Resources.Load<Material>("Materials/Test");

            foreach (Material material in tr.materials)
            {
                //material.color = new Color(0f,0f,1f);
                print(material.color);
                print(material);
            }

            /*
            for (int i = 0; i < tr.materials.Length; i++) {
                tr.materials[i] = Resources.Load<Material>("tMaterials/Test");
                print(tr.materials[i].color);
                print(tr.materials[i]);
            }*/

        }
    }
}
