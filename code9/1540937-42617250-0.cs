    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(ScriptName))]
    public class ExampleOnInspector : Editor
    {
        public Texture[] icons;
        void Awake()
        {
            //Load textures into icons by `AssetDatabase.LoadAssetAtPath<T>(assetPath)`
        }
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button(icons[0]))
                Debug.Log("Clicked the icon 0");
            if (GUILayout.Button(icons[1]))
                Debug.Log("Clicked the icon 1");
            if (GUILayout.Button(icons[2]))
                Debug.Log("Clicked the icon 2");
        }
    }
