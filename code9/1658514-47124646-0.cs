        public void _consoleWindowMethod(int id)
    {
        foreach (string _command in _CommandListEntry)
        {
            GUILayout.Label("Command :" + _command);
            GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) }); // Divider
        }
    }
