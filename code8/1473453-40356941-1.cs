    private bool[] _directionKeysPressed = new bool[4];
    private DateTime _previousKeyRelease;
    private void KeyDown(object sender, EventArgs e)
    {
        _keyPressedCount++;
        switch(keys)
        {
           case(W): _directionKeysPressed[0] = true;
           case(D): _directionKeysPressed[1] = true;
           // .................
        }
    }
    private void KeyUp(object sender, EventArgs e)
    {
        _keyPressedCount--;
        if(_keyPressedCount == 0)
        {
            // all keys released
            _directionKeysPressed[] <--- last direction...
            // reset all bools
            return;
        }
  
        // ONLY if the key is released outside the 20 ms, reset the key.
        if(_previousKeyRelease.AddMilliseconds(20) < DateTime.UTCNow)
        {  // RESET KEY
            switch(keys)
            {
                case(W): _directionKeysPressed[0] = false;
                case(D): _directionKeysPressed[1] = false;
                // .................
            }
        }
        _previousKeyRelease = DateTime.UTCNow;
    }
