using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//gui button manager
public class ButtMan : Logger {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Log("Clicked !");
        // I want to have a generalized decoupled interface here,
        // e.g., Moon.Left() or Moon.Right()
        // But unfortunately I don't know how to identify which UI button was pressed
        // so instead, i'm creating the below OnClickLeft() and OnClickRight()
        // and connecting each one manually to each button. 
        // I suppose it's not that bad.
    }
     
    public void OnClickLeft()
    {
        //to execute the method Left() on the class Moon2, it is required to access the script via an attachment to a game object
        //e.g. Moon2 moon2 = GameObject.Find("Moon").GetComponent<Moon2>(); moon2.Left();
        //alternatively, I could change the accessor to "static Left()" instead. 
        //I'm not entirely sure of the consequences, I just remember problems in the past.
        //I'll try the stsatic approach anyways, to learn
        Moon.Move(-1);
    }
    public void OnClickRight()
    {
        Moon.Move(1);
    }
}
