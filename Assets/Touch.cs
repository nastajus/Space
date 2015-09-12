using UnityEngine;
using System.Collections;

public class Touch : Logger {

    Vector3 mousePos;   //how odd it is that mouse position is V3 not V2.

	// Use this for initialization
	void Start () {
        mousePos = Input.mousePosition;
        Log("Mouse pos: " + mousePos + " (start)");
	}
	
	// Update is called once per frame
	void Update () {
        TouchTest();        
	}

    void TouchTest()
    {
        //checking which of the following Input methods fire on touch on Android.

        //works mice as well as touches #1, #2 and #3 only
        if (Input.GetMouseButtonDown(0))
            Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Log("Pressed middle click.");

        //works for mice only (tested Android 5.1 Xperia Z3)
        for (int i = 3; i < 7; i++ )
            if (Input.GetMouseButtonDown(i))
                Log(i + " click.");


        //works for touches also
        /*
        if (Input.mousePosition != mousePos)
        {
            mousePos = Input.mousePosition;
            Log("Mouse pos: " + mousePos);
        }
        */

        //Log(Input.mousePosition);
    }
}
