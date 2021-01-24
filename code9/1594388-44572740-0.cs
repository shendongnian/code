~/Assets/PropertyHolder.cs
    using System.Collections;
    using UnityEngine;
    
    
    public class PropertyHolder : MonoBehaviour
    {
    	public enum Status { A, B, C };
    
    	public Status state;
    
    	public int valForAB;
    
    	public int valForA;
    	public int valForC;
    
    	public bool controllable;
    
    	void Start()
    	{
    
    	}
    
    	void Update()
    	{
    
    	}
    }
~/Assets/Editor/PropertyHolderEditor.cs
    using UnityEditor;
    using UnityEngine;
    
    [CustomEditor(typeof (PropertyHolder)), CanEditMultipleObjects]
    public class PropertyHolderEditor : Editor
    {
    
    	public SerializedProperty
    	state_Prop,
    	valForAB_Prop,
    	valForA_Prop,
    	valForC_Prop,
    	controllable_Prop;
    
    	void OnEnable()
    	{
    		// Setup the SerializedProperties
    		state_Prop = serializedObject.FindProperty("state");
    		valForAB_Prop = serializedObject.FindProperty("valForAB");
    		valForA_Prop = serializedObject.FindProperty("valForA");
    		valForC_Prop = serializedObject.FindProperty("valForC");
    		controllable_Prop = serializedObject.FindProperty("controllable");
    	}
    
    	public override void OnInspectorGUI()
    	{
    		serializedObject.Update();
    
    		EditorGUILayout.PropertyField(state_Prop);
    
    		PropertyHolder.Status st = (PropertyHolder.Status) state_Prop.enumValueIndex;
    
    		switch (st)
    		{
    			case PropertyHolder.Status.A:
    				EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));
    				EditorGUILayout.IntSlider(valForA_Prop, 0, 10, new GUIContent("valForA"));
    				EditorGUILayout.IntSlider(valForAB_Prop, 0, 100, new GUIContent("valForAB"));
    				break;
    
    			case PropertyHolder.Status.B:
    				EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));
    				EditorGUILayout.IntSlider(valForAB_Prop, 0, 100, new GUIContent("valForAB"));
    				break;
    
    			case PropertyHolder.Status.C:
    				EditorGUILayout.PropertyField(controllable_Prop, new GUIContent("controllable"));
    				EditorGUILayout.IntSlider(valForC_Prop, 0, 100, new GUIContent("valForC"));
    				break;
    
    		}
    
    		serializedObject.ApplyModifiedProperties();
    	}
    }
