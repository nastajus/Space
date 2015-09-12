using UnityEngine;
using System.Collections;

public class Moon2 : Stats {

    private static GameObject moon;

	// Use this for initialization
	void Start () {
        moon = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    //Input.GetAxis("Horiztonal")
	}

    static Vector3 delta = new Vector3(1, 0, 0);

    public static void Left()
    {
        moon.transform.position -= delta;
    }

    public static void Right()
    {
        moon.transform.position += delta;
    }

}
