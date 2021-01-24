    public float textureWidth = 400;
    public float textureHeight = 400;
    
    public Texture2D img1;
    void OnGUI()
    {
        GUILayout.Label(img1, GUILayout.Width(textureWidth), GUILayout.Height(textureHeight));
    }
