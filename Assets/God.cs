using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

	bool leftDown = false;
	bool rightDown = false;

	public void Left(int status){
		switch (status) {//0=Off 1=On
		case 0: leftDown = false;break;
		case 1: leftDown = true;break;
		}
	}
	public void Right(int status){
		switch (status) {
		case 0: rightDown = false;break;
		case 1: rightDown = true;break;
		}
	}


	public void Update(){
		if (leftDown) {
			LeftPressed();
		}
		if (rightDown) {
			RightPressed();
		}
	}

    public void LeftPressed()
    {
        BroadcastMessage("Move", -1);
    }

    public void RightPressed()
    {
        BroadcastMessage("Move", 1);
    }
}
