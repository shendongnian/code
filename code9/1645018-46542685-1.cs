    using UnityEditor;
    using UnityEngine;    
    [CustomEditor(typeof(MyScript))]
    public class MyScriptEditor : Editor
    {
    	void OnInspectorGUI()
    	{
    		var myScript = (MyScript)target;
    		EditorGUILayout.CurveField("curve", myScript.myCurve);
    	}
    }
