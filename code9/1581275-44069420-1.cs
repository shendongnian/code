    public Texture btnTexture;
    void OnGUI()
    {
        if (!btnTexture)
        {
            Debug.LogError("Please assign a texture on the inspector")
            return;
        }
        if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
            Debug.Log("Clicked the button with an image");
    
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            Debug.Log("Clicked the button with text");
    
    }
