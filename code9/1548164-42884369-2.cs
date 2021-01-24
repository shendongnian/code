    //dummy local variables
    string RootPath = null;
    PathType DesiredPathType = PathType.Abs;
    string BuildName = "";
    string OutputPath = "";
    bool Subfolders = false;
    //Displays absolute root path
    EditorGUILayout.SelectableLabel("Root Directory: " + RootPath, EditorStyles.miniLabel, GUILayout.MaxHeight(16));
    //Creates BuildPath
    EditorGUILayout.EnumPopup("Path Type", DesiredPathType);
    //BuildName TextField
    BuildName = EditorGUILayout.TextField(new GUIContent("Build Name"), BuildName);
    //OutputPath directory selector
    GUILayout.BeginHorizontal();
    GUIStyle Style = EditorStyles.textField;
    Style.alignment = TextAnchor.UpperLeft;
    OutputPath = EditorGUILayout.TextField(new GUIContent("Output Path"), OutputPath, Style);
            
    GUILayout.Button(new GUIContent("O"), EditorStyles.label, GUILayout.MaxHeight(16), GUILayout.MaxWidth(19));
    GUILayout.EndHorizontal();
    //SubFolders toggle
    Subfolders = EditorGUILayout.Toggle(new GUIContent("Subfolder per Platform"), Subfolders);
