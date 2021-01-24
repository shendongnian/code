    void OnGUI()
    {
        foreach (UnityEngine.Touch touch in Input.touches)
        {
            guitextureindi = false;
        }
    
        if (guitextureindi) 
        {
            GUILayout.Label (img1);
        }
    }
