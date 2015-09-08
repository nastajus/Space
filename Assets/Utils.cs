using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utils : MonoBehaviour {

    //@percentage = 0.001 to 1.000
    public static float PercentToPixel(float percentage, float relativeTo)
    {
        //const float minScreenHeight = 180f;
        const float minPercentage = 0.01f;
        const float maxPercentage = 1f;

        if (percentage < minPercentage)
        {
            Stats.Log("Percentage input <color=maroon>too small</color>, increased from " + percentage + " to " + minPercentage);
            percentage = minPercentage;
        }
        else if (percentage > maxPercentage)
        {
            Stats.Log("Percentage input <color=maroon>too large</color>, <color=orange>decreased from " + percentage + " to " + maxPercentage);
            percentage = maxPercentage;
        }
        float pixels = percentage * relativeTo;
        return pixels;
    }

    ////@pixels = 1 or more
    //public static float PixelsToPercent(float pixels, float relativeTo)
    //{
    //    //const float minScreenHeight = 180f;
    //    const float minPixels = 1f;
    //
    //    if (pixels < minPixels)
    //    {
    //        Manager.DebugLogGUI("Percentage input <color=maroon>too small</color>, increased from " + pixels + " to " + minPixels);
    //        pixels = minPixels;
    //    }
    //    float percent = pixels / relativeTo;
    //    return pixels;
    //}

    //C# Modulus Is WRONG!
    //http://answers.unity3d.com/questions/380035/c-modulus-is-wrong-1.html
    public static float nfmod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }


    /*
    public static YummyPowerUps goUpParent<TITS>(Transform current, List<Transform> exceptions = null) where TITS : Component
    {
        Transform parent = current.transform.parent; 

        //base cases
        if (parent == null)  { 
            Stats.DebugLogGUI("Top found");

            //compScriptSeek.GetType;
            //System.Type t = compScriptSeek.GetType;
            //System.Type tt = typeof(compScriptSeek);


            TITS comp = current.GetComponent<TITS>();
            if (comp != null)
                return comp;
            
            return null; 
        }
        //alternate base case
        if (exceptions != null && exceptions.Contains(parent)) { Stats.DebugLogGUI("Excused parent found: " + parent); return null; }


        //recursive case
        goUpParent(parent, compScriptSeek);

        Stats.DebugLogGUI(current.name);

        return null;
    }
     */
}
