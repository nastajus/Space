using UnityEngine;
using System.Collections;

//parallax scrolling support 
public class Scrolling : MonoBehaviour {

    public GameObject background;
    private GameObject background2;
    float scrollSpeed = 1f;
    enum Dir { Left = -1, Right = 1, None = 0 };
    Dir dir = Dir.Right;
    //private GameObject background2;
    //private GameObject background3;

	// Use this for initialization
	void Start () {

        //find background
        background = GameObject.FindWithTag("Background");
        if (background == null) { Debug.LogWarning("no tag \"Background\" exists, please place and tag one in scene!"); return; }
        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        if (sr == null) { Debug.LogWarning("background is not of type sprite renderer, please use!"); return;  }

        //ensure it's furthest back
        EnsureFurthestBack(sr);


        //duplicate background & reverse
        Sprite sp = sr.sprite;
        Vector3 pos = background.transform.position - new Vector3(sp.bounds.size.x, 0, 0);
        background2 = (GameObject)Instantiate(background, pos, Quaternion.identity);
        background2.transform.localScale = new Vector3(-1, 1, 1);
//            new GameObject(background.name + "2");


        //position it centered on camera


        //verify image size fits within bounds of screen resolution.
        //the height or double width must fit in res
        //get res
        //if (Screen.width > background.GetComponent<Bounds>().size.x) {  }

	}
	
	// Update is called once per frame
	void Update () {

        if (background == null) { return; }
        //scrolling bg:
        Vector3 pos = background.transform.position;
        background.transform.position = new Vector3(pos.x + 1 * (int)dir * scrollSpeed * Time.deltaTime, pos.y, pos.z);

        pos = background2.transform.position;
        background2.transform.position = new Vector3(pos.x + 1 * (int)dir * scrollSpeed * Time.deltaTime, pos.y, pos.z);
        
        //assign one background instance to loop when outside camera

        //detect outside camera
            
	}

    void EnsureFurthestBack(SpriteRenderer target)
    {
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        int? lowestOrder = null;
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            SpriteRenderer sr = g.GetComponent<SpriteRenderer>();
            if (sr == null) { continue; }
            if (lowestOrder == null) { 
                lowestOrder = sr.sortingOrder; 
                continue;
            }
            else if (sr.sortingOrder < lowestOrder) {
                lowestOrder = sr.sortingOrder;
            }
        }
        if (lowestOrder != null && target.sortingOrder > (int)lowestOrder)
        {
            target.sortingOrder = (int)lowestOrder - 1;
            Debug.LogWarning(target.name + " set to furthest back with sorting order: " + target.sortingOrder );
        }
    }
}
