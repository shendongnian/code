    public static void ProcessKeyDown(KeyEventArgs args)
    {
        // Detect keyboard input controls you may have issues with.
        // If one has keyboard focus, skip hotkey processing.
        if (Keyboard.FocusedElement is TextBox) {
            return;
        }
    
        // ...
    }
