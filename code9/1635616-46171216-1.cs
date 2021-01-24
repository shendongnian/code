    bool keyPressRegistered = false;
    ...
    if (keyboardState.IsKeyDown(Keys.I) && !keyPressRegistered)
    {
        keyPressRegistered = true;
        GameInfo.gameInfo.debugMode = !GameInfo.gameInfo.debugMode;
    }
    ...
 
    keyPressRegistered = !(keyPressRegistered && keyboardState.IsKeyUp(Keys.I));
