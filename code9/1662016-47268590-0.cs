    // Class scoped instance of the GlobalKeyboardHook class from the link
    GlobalKeyboardHook gkh = new GlobalKeyboardHook();
    
    public MyConstructor()
    {
        // tell the class which keys you care about - don't worry about "modifier keys" such as the windows key
        gkh.HookedKeys.Add(Keys.Right);
        gkh.HookedKeys.Add(Keys.Left);
        gkh.HookedKeys.Add(Keys.Up);
        gkh.HookedKeys.Add(Keys.Down);
    
        // add a handler for the keydown event
        gkh.KeyDown += ghk_KeyDown;
    }
    
    // implement your handler
    void gkh_KeyDown(object sender, KeyEventArgs e)
    {
        // this will fire regardless of which arrow was pushed.  Check that the user is holding the windows key, and check which arrow they pushed
        if (e.KeyCode == Keys.Right && (e.Modifiers == Keys.LWin || e.Modifiers == Keys.RWin))
        {
            // handle windows key + right arrow here
        }
    }
