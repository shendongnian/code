    private bool[] _directionKeysPressed = new bool[4];
    private DateTime _previousKeyRelease;
    private void KeyDown(object sender, EventArgs e)
    {
        _keyPressedCount++;
        switch(keys)
        {
           case(A): _directionKeysPressed[0] = true;
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
            return;
        }
  
        if(_previousKeyRelease.AddMilliseconds(20) < DateTime.UTCNow)
        {  // RESET KEY
            switch(keys)
            {
                case(A): _directionKeysPressed[0] = true;
                // .................
            }
        }
        _previousKeyRelease = DateTime.UTCNow;
    }
