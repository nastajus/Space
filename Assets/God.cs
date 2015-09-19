using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {

    public void LeftPressed()
    {
        BroadcastMessage("Move", -1);
    }

    public void RightPressed()
    {
        BroadcastMessage("Move", 1);
    }
}
