using UnityEngine;
using System.Collections;

//parallax scrolling support 
public class Scrolling : MonoBehaviour {

    public GameObject background;
    float scrollSpeed = 5f;
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

        Texture2D tx = textureFromSprite(sr.sprite);

        Color32 col = AverageColorFromTexture(tx);

        //UnityException: Texture 'space' is not readable, the texture memory can not be accessed from scripts. You can make the texture readable in the Texture Import Settings.
        Camera.main.backgroundColor = col;


        //duplicate background


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
        background.transform.position = new Vector3(pos.x + 1 * scrollSpeed * Time.deltaTime, pos.y, pos.z);

            
	}

    void EnsureFurthestBack(SpriteRenderer target)
    {
        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
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
        if (lowestOrder != null)
        {
            target.sortingOrder = (int)lowestOrder - 10;
            Debug.LogWarning(target.name + " set to furthest back with sorting order: " + target.sortingOrder );
        }
    }


    /*
     * http://forum.unity3d.com/threads/average-color-from-texture.145331/
     */
    Color32 AverageColorFromTexture(Texture2D tex)
    {

        Color32[] texColors = tex.GetPixels32();
        int total = texColors.Length;

        float r = 0;
        float g = 0;
        float b = 0;

        for (int i = 0; i < total; i++)
        {
            r += texColors[i].r;
            g += texColors[i].g;
            b += texColors[i].b;
        }

        return new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0);

    }

    //http://answers.unity3d.com/questions/651984/convert-sprite-image-to-texture.html
    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
         {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }

}
