    private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
    {
        if (args.Handled)
        {
            return;
        }
        
        switch (args.VirtualKey)
        {
            case VirtualKey.GamepadA:
                // Gamepad A button was pressed
                break;
            case VirtualKey.GamepadB:
                // Gamepad B button was pressed
                break;
            case VirtualKey.GamepadX:
                // Gamepad X button was pressed
                break;
            case VirtualKey.GamepadY:
                // Gamepad Y button was pressed
                break;
        }
    }
