using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Logger : MonoBehaviour {

	//box
    public static float margin;

    //debug window stuff
    static bool guiInitDone = false;
    static Rect rectDebugArea;
    static List<Rect> rectWindows;
    static Vector2 scrollPosition;
    static int fontHD;
    static int fontHS;
    static string debugCumulativeStr = "";
    static int debugLogLineCount = 0;
    static bool debugStrChanged = false;
    static GUIStyle debugStyle;

	// Try not to use Start, will execute for each object that inherits this Stats class.
    // This Stats class will remain inheriting from Monobehavior for easy access to Log(),
    // while still permitting normal goodness
	void Start () {		
	}

    // Note: this is horribly inefficient, simply playing and immediately pausing causes 546 logs for 3 objects.
    // This would be better refactored into a singleton object, but fuck that for now.
    // Let it be wasteful until I have a relevant performance impact
	void OnGUI(){

        if (!guiInitDone) { InitGUI(); }
        GUILayout.BeginArea(rectDebugArea);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(rectDebugArea.width), GUILayout.Height(rectDebugArea.height));
        GUILayout.Box(new GUIContent(debugCumulativeStr, "Mouse Over TextArea"), debugStyle);
        float scrollAmt = Input.GetAxis("Mouse ScrollWheel");
        //this isn't mutually exclusive, the else is still called on some frames. Sigh
        if (GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
        {  //Event.current.type == EventType.Repaint &&
            scrollPosition = new Vector2(0, scrollPosition.y + scrollAmt * 10);
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();

        if (debugStrChanged)
        {
            int estimatedStyleMargins = fontHD;
            scrollPosition = new Vector2(0, scrollPosition.y + fontHD + estimatedStyleMargins);
            debugStrChanged = false;
        }
	}

    static void InitGUI()
    {
        margin = Utils.PercentToPixel(0.05f, Screen.width);
        float debugAreaHeight = Utils.PercentToPixel(0.20f, Screen.height);
        rectDebugArea = new Rect(margin * 3, debugAreaHeight - margin, Screen.width - margin * 6, debugAreaHeight);
        //Stats.DebugLogGUI(rectDebugArea);

        scrollPosition = Vector2.zero;
        if (Application.platform == RuntimePlatform.Android)
        {
            fontHD = (int)Utils.PercentToPixel(0.03f, Screen.width);
            fontHS = (int)Utils.PercentToPixel(0.03f, Screen.width);
        }
        else
        {
            fontHD = (int)Utils.PercentToPixel(0.02f, Screen.width);
            fontHS = (int)Utils.PercentToPixel(0.02f, Screen.width);
        }

        debugStyle = new GUIStyle(GUI.skin.textArea);
        debugStyle.normal.textColor = Color.white;
        debugStyle.richText = true;
        debugStyle.wordWrap = false;
        debugStyle.fontSize = fontHD;
        debugStyle.alignment = TextAnchor.MiddleLeft;
        //debugStyle.fontStyle = FontStyle.Bold;

        guiInitDone = true;
    }

    public static void Log(string str)
    {
        string output = "\n" + ++debugLogLineCount + ") " + str;
        //following commented out due to bug
        //const int maxLengthDetermined = 2 ^ 14 - 1;  //not uint16 size, that's 65k... oh well, w/e.
        //int amountOver = cumulativeDebugStr.Length + output.Length - maxLengthDetermined;
        //
        //if (amountOver > 0)
        //{
        //    cumulativeDebugStr = cumulativeDebugStr.Substring(amountOver + 1); // +1 tossed in for safetfy w/o pondering.
        //}
        debugCumulativeStr += output;
        debugStrChanged = true; //used to check to push scrollview of debugArea to bottom
        Debug.Log(output.Substring(1)); //sub bc "\n"
    }

    public static void Log(Vector3 vect)
    {   
        Log(vect.ToString());
    }
    public static void Log(System.Object obj)
    {
        Log(obj.ToString());
    }
}
