    private bool _display;
    private bool _log;
    public Vector2 scrollPosition;
    void OnGUI()
    {
        if (GUILayout.Button("Log")) _log = !_log;
        if (_log)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height-130));
            for(int i= Utilities.logs.Count-1; i >0; i--)
            {
                GUILayout.Label(Utilities.logs[i]);
            }
            GUILayout.EndScrollView();
            if (GUILayout.Button("Clear"))
                Utilities.logs.Clear();
            if (GUILayout.Button("Copy To Clipboard"))
                GUIUtility.systemCopyBuffer = CopyToClipboard();
        }
    
    }
    private string CopyToClipboard()
    {
        string response = null;
        for (int i = Utilities.logs.Count - 1; i > 0; i--)
        {
            response += Utilities.logs[i] + "\n";
        }
        return response;
    }
