    using UnityEditor;
    using UnityEngine;
    
    public class SceneGUI : EditorWindow
    {
        [MenuItem("Window/Scene GUI/Enable")]
        public static void Enable()
        {
            SceneView.onSceneGUIDelegate += OnScene;
            Debug.Log("Scene GUI : Enabled");
        }
    
        [MenuItem("Window/Scene GUI/Disable")]
        public static void Disable()
        {
            SceneView.onSceneGUIDelegate -= OnScene;
            Debug.Log("Scene GUI : Disabled");
        }
    
        private static void OnScene(SceneView sceneview)
        {
            Handles.BeginGUI();
            if (GUILayout.Button("Destroy Objects", GUILayout.Width(100), GUILayout.Height(100)))
            {
                
            }
    
            Handles.EndGUI();
        }
    }
