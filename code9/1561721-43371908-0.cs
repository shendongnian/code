        using UnityEngine;
        
        #if UNITY_EDITOR
        using UnityEditor;
        #endif
        
        public class YOUR_CLASS_NAME : THE_CLASS_YOU_DERIVE_FROM
        {
        }
        
        #if UNITY_EDITOR
        [CustomEditor(typeof(YOUR_CLASS_NAME))]
        public class YOUR_CLASS_NAME_CUSTOM_EDITOR : Editor
        {
            public override void OnInspectorGUI()
            {
                // If you want to display THE_CLASS_YOU_DERIVE_FROM as it is usually on the inspector (doesn't completely work with some components that have "complex" editor)
                base.OnInspectorGUI();
        
                // Otherwise feel free to do what you want
            }
        }
        #endif
