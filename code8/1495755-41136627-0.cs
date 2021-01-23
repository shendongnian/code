    var keysPressed = MyKeys.GetPressedKeys()
        .Where(k => !OldKeys.GetPressedKeys().Contains(k));
    foreach(var key in keysPressed)
    {
        // Do your logic
    }
    OldKeys = MyKeys;
    
    MyKeys = Keyboard.GetState();
