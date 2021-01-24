    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor (typeof (BuffData))]
    public class BuffDataEditor : Editor
    {
        private const int DescriptionWidthPadding = 35;
        private const float DescriptionHeightPadding = 1.25f;
        private const string AttributesHelpText = 
            "Choose which attributes are to be affected by this buff and by how much.\n" +
            "Note: the calculation type should match the attribute's implementation.";
    
        private SerializedProperty nameProperty;
        private SerializedProperty descriptionProperty;
        private SerializedProperty iconProperty;
        private SerializedProperty attributeBuffsProperty;
    
        private void OnEnable ()
        {
            nameProperty = serializedObject.FindProperty ("name");
            descriptionProperty = serializedObject.FindProperty ("description");
            iconProperty = serializedObject.FindProperty ("icon");
            attributeBuffsProperty = serializedObject.FindProperty ("attributeBuffs");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update ();
    
            nameProperty.stringValue = EditorGUILayout.TextField ("Name", nameProperty.stringValue);
            EditorGUILayout.LabelField ("Description:");
            GUIStyle descriptionStyle = new GUIStyle (EditorStyles.textArea)
            {
                wordWrap = true,
                padding = new RectOffset (6, 6, 6, 6),
                fixedWidth = Screen.width - DescriptionWidthPadding
            };
            descriptionStyle.fixedHeight = descriptionStyle.CalcHeight (new GUIContent (descriptionProperty.stringValue), Screen.width) * DescriptionHeightPadding;
            EditorGUI.indentLevel++;
            descriptionProperty.stringValue = EditorGUILayout.TextArea (descriptionProperty.stringValue, descriptionStyle);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space ();
            iconProperty.objectReferenceValue = (Texture2D) EditorGUILayout.ObjectField ("Icon", iconProperty.objectReferenceValue, typeof (Texture2D), false);
            EditorGUILayout.Space ();
            EditorGUILayout.HelpBox (AttributesHelpText, MessageType.Info);
            EditorGUILayout.PropertyField (attributeBuffsProperty, true);
    
            serializedObject.ApplyModifiedProperties();
        }
    }
