using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ETrig : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //add an event trigger by script
        //http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
        /*
        EventTrigger trigger = GetComponentInParent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { Foo(); });
        trigger.delegates.Add(entry);
        */
	}


    public void dynamicallyAddEvent(){
        /*
        GameObject buttonObject = gameObject;

        //Get the event trigger attached to the UI object
        EventTrigger eventTrigger = buttonObject.GetComponent<EventTrigger>();

        //Create a new entry. This entry will describe the kind of event we're looking for
        // and how to respond to it
        EventTrigger.Entry entry = new EventTrigger.Entry();

        //This event will respond to a drop event
        entry.eventID = EventTriggerType.Drop;

        //Create a new trigger to hold our callback methods
        entry.callback = new EventTrigger.TriggerEvent();

        //Create a new UnityAction, it contains our DropEventMethod delegate to respond to events
        UnityEngine.Events.UnityAction<BaseEventData> callback =
            new UnityEngine.Events.UnityAction<BaseEventData>(DropEventMethod);

        //Add our callback to the listeners
        entry.callback.AddListener(callback);

        //Add the EventTrigger entry to the event trigger component
        eventTrigger.delegates.Add(entry);
        */
    }
}
