using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

public class TouchCreator
{
    static BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
    static Dictionary<string, FieldInfo> fields;

    object touch;

    public float deltaTime { get { return ((TouchCreator)touch).deltaTime; } set { fields["m_TimeDelta"].SetValue(touch, value); } }
    public int tapCount { get { return ((TouchCreator)touch).tapCount; } set { fields["m_TapCount"].SetValue(touch, value); } }
    public TouchPhase phase { get { return ((TouchCreator)touch).phase; } set { fields["m_Phase"].SetValue(touch, value); } }
    public Vector2 deltaPosition { get { return ((TouchCreator)touch).deltaPosition; } set { fields["m_PositionDelta"].SetValue(touch, value); } }
    public int fingerId { get { return ((TouchCreator)touch).fingerId; } set { fields["m_FingerId"].SetValue(touch, value); } }
    public Vector2 position { get { return ((TouchCreator)touch).position; } set { fields["m_Position"].SetValue(touch, value); } }
    public Vector2 rawPosition { get { return ((TouchCreator)touch).rawPosition; } set { fields["m_RawPosition"].SetValue(touch, value); } }

    public TouchMan Create()
    {
        return (TouchMan)touch;
    }

    public TouchCreator()
    {
        touch = new TouchMan();
    }

    static TouchCreator()
    {
        fields = new Dictionary<string, FieldInfo>();
        foreach (var f in typeof(TouchMan).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            fields.Add(f.Name, f);
            Debug.Log("name: " + f.Name);
        }
    }
}