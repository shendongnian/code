    public override void OnInspectorGUI()
    {
        TestScript script = (TestScript)target;
        script.a = EditorGUILayout.Vector2Field("a", script.a);
        script.b = EditorGUILayout.Vector2Field("b", script.b);
        script.c = EditorGUILayout.Vector2Field("c", script.c);
        if(Gui.changed)
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
    }
