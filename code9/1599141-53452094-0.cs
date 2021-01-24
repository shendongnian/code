    KeyEvent k = new KeyEvent
    {
    	WindowsKeyCode = 0x0D, // Enter
    	FocusOnEditableField = true,
    	IsSystemKey = false,
    	Type = KeyEventType.KeyDown
    };
    
    _browser.GetBrowser().GetHost().SendKeyEvent(k);
    
    Thread.Sleep(100);
    
    k = new KeyEvent
    {
    	WindowsKeyCode = 0x0D, // Enter
    	FocusOnEditableField = true,
    	IsSystemKey = false,
    	Type = KeyEventType.KeyUp
    };
    
    _browser.GetBrowser().GetHost().SendKeyEvent(k);
    
    Thread.Sleep(100);
