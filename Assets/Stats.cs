using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour {

	//box
    public static float margin;

	private enum units { mps2kmh };

	private Dictionary<units, float> convert = new Dictionary<units, float>(){
		{units.mps2kmh, 3.6f},
	};



    //debug window stuff
    bool guiInitDone = false;
    Rect rectDebugArea;
    Vector2 scrollPosition;
    int fontHD;
    int fontHS;


    static string debugCumulativeStr = "";
    static int debugLogLineCount = 0;
    static bool debugStrChanged = false;


    GUIStyle debugStyle;
    GUIStyle statsStyle;


	// Use this for initialization
	void Start () {
		//player
		margin = Utils.PercentToPixel(0.05f, Screen.width);

	}
	


	void OnGUI(){

        if (!guiInitDone) { InitGUI(); }
        //GUI.TextArea(rectDebugArea, cumulativeDebugStr, textStyle);

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

        //top left
        string presentationStatsStr = //"PLAYER STATS:"
            //+ "\nDISTANCE: " + (int)metersTraveled 
        "POINTS: "
        + "\nSPEED M/S: "
        + "\nSPEED KM/H: "
        + "\nTIME: ";


        string debugStatsStr =
        "\nPOSITION: "
        + "\nINST. SPEED M/S: "
        + "\nINST. SPEED KM/H: "
        + "\nSECTIONS: ";


        Vector2 presentationStatsSz = statsStyle.CalcSize(new GUIContent(presentationStatsStr));
        GUI.Box(new Rect(margin, margin, presentationStatsSz.x, presentationStatsSz.y), presentationStatsStr, statsStyle);

        Vector2 debugStatsSz = statsStyle.CalcSize(new GUIContent(debugStatsStr));
        GUI.Box(new Rect(Screen.width - debugStatsSz.x - margin, margin, debugStatsSz.x, debugStatsSz.y), debugStatsStr, statsStyle);


	}


    void InitGUI()
    {

        float debugAreaHeight = Utils.PercentToPixel(0.20f, Screen.height);
        rectDebugArea = new Rect(margin, Screen.height - debugAreaHeight - margin, Screen.width - margin * 2, debugAreaHeight);
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

        statsStyle = new GUIStyle(GUI.skin.textArea);
        statsStyle.normal.textColor = Color.white;
        //statsStyle.fontStyle = FontStyle.Bold;
        statsStyle.richText = true;
        statsStyle.fontSize = fontHS;
        statsStyle.alignment = TextAnchor.MiddleCenter;

        guiInitDone = true;
    }


    public static void DebugLogGUI(System.Object obj)
    {
        Log( obj.ToString() );
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

}
