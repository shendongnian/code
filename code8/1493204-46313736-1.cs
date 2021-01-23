    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(LevelController))]
    
    public class InspectorCustomizer : Editor
    {
    
        public override void OnInspectorGUI()   
        {
            //DrawDefaultInspector();
    
            serializedObject.Update();
    		EditorGUILayout.PropertyField(serializedObject.FindProperty("Levels"), true);
            serializedObject.ApplyModifiedProperties();
        }
    }
