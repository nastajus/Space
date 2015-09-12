using UnityEngine;
using System.Collections;

public class Test : Logger {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) { 
            Log("Input.GetMouseButtonDown(0)"); }
        if (Input.GetMouseButtonDown(1)) { 
            Log("Input.GetMouseButtonDown(1)"); }
        if (Input.touches.Length > 0) { 
            Log("Input.touches.Length: " + Input.touches.Length);
            string log = "touches[]: ";
            foreach (var touch in Input.touches) { log += touch; } Log(log);
        }
//        if (Input.mousePosition != Vector3.zero) { 
  //          Log(Input.mousePosition); }
    }
}
