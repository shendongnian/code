    private void OnGUI()
    { 
        GUILayout.BeginHorizontal();
        for (var i = 0; i < 6; i++)
        {
            var buttonResult = GUILayout.Button(string.Format("Button {0}", i));
            var rect = GUILayoutUtility.GetLastRect();
            var pos = Event.current.mousePosition;
            if (rect.Contains(pos))
            {
                OnMouseOver(i);
            }
            if (buttonResult)
            {
                OnButtonClick(i);
            }
        }
        GUILayout.EndHorizontal();
    }
    private void OnButtonClick(int buttinIndex)
    {
        Debug.LogFormat("OnButtonClick {0}", buttinIndex);
    }
    private void OnMouseOver(int buttinIndex)
    {
        Debug.LogFormat("OnMouseOver {0}", buttinIndex);
    }
