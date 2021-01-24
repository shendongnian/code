    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    using System.IO;
    [CustomEditor(typeof(MonoScript))]
    public class SimpleEditCore : Editor {
    public string text;
    public string path;
    void OnEnable()
    {
         text = serializedObject.FindProperty ("text");         
    }
    public override void OnInspectorGUI()
    {
        path = AssetDatabase.GetAssetPath (target);
        EditorGUILayout.LabelField ("Location: ", path.ToString ());
        text = EditorGUILayout.TextArea (text);
        if (GUILayout.Button ("Save!")) {
            StreamWriter writer = new StreamWriter(path, false);
            writer.Write (text);
            writer.Close ();
            Debug.Log ("[SimpleEdit] Yep!");
        }
    }
    }
