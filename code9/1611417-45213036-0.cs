    using UnityEngine;
    
    using System.Collections.Generic;
    
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    
    
    public static class EditorUtil
    {
    
    
    
    	static string m_EditorResourcesPath = string.Empty;
    	private static string path = string.Empty;
    
    	internal static string editorResourcesPath {
    
    
    
    		get {
    			if (string.IsNullOrEmpty (m_EditorResourcesPath)) {
    				string path;
    
    				if (SearchForEditorResourcesPath (out path))
    					m_EditorResourcesPath = path;
    				else
    					Debug.LogError ("Unable to locate editor resources. Make sure the PostProcessing package has been installed correctly.");
    			}
    
    			return m_EditorResourcesPath;
    		}
    	}
    
    	static bool SearchForEditorResourcesPath (out string path)
    	{
    		path = string.Empty;
    
    		string searchStr = EditorUtil.path;
    		string str = null;
    		#if UNITY_EDITOR
    		foreach (var assetPath in AssetDatabase.GetAllAssetPaths()) {
    			if (assetPath.Contains (searchStr)) {
    				str = assetPath;
    				break;
    			}
    		}
    		#endif
    		if (str == null)
    			return false;
    
    		path = str.Substring (0, str.LastIndexOf (searchStr) + searchStr.Length);
    		return true;
    	}
    
    	internal static T Load<T> (string path, string name) where T : Object
    	{
    		#if UNITY_EDITOR
    		EditorUtil.path = path;
    		return AssetDatabase.LoadAssetAtPath<T> (editorResourcesPath + name);
    		#else
    	return null
    		#endif
    	}
    
    	private static List<string> layers;
    	private static string[] layerNames;
    
    	public static LayerMask LayerMaskField (string label, LayerMask selected)
    	{
    		if (layers == null) {
    			layers = new List<string> ();
    			layerNames = new string[4];
    		} else {
    			layers.Clear ();
    		}
    
    		int emptyLayers = 0;
    		for (int i = 0; i < 32; i++) {
    			string layerName = LayerMask.LayerToName (i);
    
    			if (layerName != "") { 
    				layers.Add (layerName);
    			} else {
    				emptyLayers++;
    			}
    		}
    
    		if (layerNames.Length != layers.Count) {
    			layerNames = new string[layers.Count];
    		}
    
    		for (int i = 0; i < layerNames.Length; i++)
    			layerNames [i] = layers [i];
    		#if UNITY_EDITOR
    		selected.value = EditorGUILayout.MaskField (label, selected.value, layerNames);
    		#endif
    		return selected;
    	}
    
    	public static Rect GetCurrentRect (float fieldSize = 18)
    	{
    		return GUILayoutUtility.GetRect (GUIContent.none, GUIStyle.none, GUILayout.Height (fieldSize));
    	}
    
    	public static GameObject GetSelectedGameObject ()
    	{
    		#if UNITY_EDITOR
    		return Selection.activeGameObject;
    		#else
    	return null
    		#endif
    	}
    
    
    
    	public static AnimationClip GetAnimationClipFromAnimator (Animator animator, string name)
    	{
    		if (animator == null)
    			return null;
    
    		foreach (AnimationClip animClip in animator.runtimeAnimatorController.animationClips) {
    			if (animClip.name == name)
    				return animClip;
    		}
    		return null;
    	}
    
    }
