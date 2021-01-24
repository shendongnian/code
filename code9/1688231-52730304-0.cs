    void KeyboardCallback(IAsyncResult Result)
    {
        var text = Guide.EndKeyboardInput(result);
        //text now contains your keyboard input
    }
    
    void CreateButtonClicked(Panel panel)
    {
        ar = Guide.BeginShowKeyboardInput(PlayerIndex.One, "Game1", "Enter a username", "", KeyboardCallback, null);
    }
