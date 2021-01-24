    bool keyPressRegistered = false;
    ...
    if (keyboardState.IsKeyDown(Keys.I) && !keyPressRegistered)
    {
        keyPressRegistered = true;
        GameInfo.gameInfo.debugMode = !GameInfo.gameInfo.debugMode;
    }
    ...
 
    if (keyboardState.IsKeyUp(Keys.I) && keyPressRegistered)
    {
        keyPressRegistered = false;
    }
