    int value = 1;
    string label = "User Name: ";
    void OnGUI()
    {
        GUIStyle TextFieldStyles = new GUIStyle(EditorStyles.textField);
        GUI.contentColor = Color.white;
        GUI.color = Color.white;
    
        //Value Color
        TextFieldStyles.normal.textColor = Color.white;
    
        //Label Color
        EditorStyles.label.normal.textColor = Color.yellow;
    
        EditorGUILayout.IntField(label, value, TextFieldStyles);
    }
