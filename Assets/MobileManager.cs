using UnityEngine;
using System.Collections;

//manages keypresses for Android Menu system (only for now)
public class MobileManager : Logger {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Home))
        {
            //Home button pressed! write every thing you want to do
            Log("\"HOME\" KEY PRESSED");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Log("\"ESCAPE\" KEY PRESSED");
            //Escape button codes
        }
        if (Input.GetKey(KeyCode.Menu))
        {
            Log("\"MENU\" KEY PRESSED. Quitting.");
            Application.Quit();
        }

	}
}
