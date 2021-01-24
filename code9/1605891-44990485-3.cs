    public int LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            // Get the mouse WM from the wParam parameter
            var wmMouse = (MouseMessage) wParam;
            if (wmMouse == MouseMessage.WM_LBUTTONDOWN && LeftButtonState == ButtonState.Released)
            {
                Logger.Debug("Left Mouse down");
            }
            if (wmMouse == MouseMessage.WM_LBUTTONUP && LeftButtonState == ButtonState.Down)
            {
                Logger.Debug("Left Mouse up");
            }
            if (wmMouse == MouseMessage.WM_RBUTTONDOWN && RightButtonState == ButtonState.Released)
            {
                Logger.Debug("Right Mouse down");
            }
            if (wmMouse == MouseMessage.WM_RBUTTONUP && RightButtonState == ButtonState.Down)
            {
                Logger.Debug("Right Mouse up");
            }
        }
        // Pass the hook information to the next hook procedure in chain
        return NativeMethods.CallNextHookEx(_hGlobalLlMouseHook, nCode, wParam, lParam);
    }
