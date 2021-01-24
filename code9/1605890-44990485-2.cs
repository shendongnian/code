    private void ClearHook()
    {
        Logger.Debug("Deleting global mouse hook");
    
        if (_hGlobalLlMouseHook != IntPtr.Zero)
        {
            // Unhook the low-level mouse hook
            if (!NativeMethods.UnhookWindowsHookEx(_hGlobalLlMouseHook))
                throw new Win32Exception("Unable to clear MouseHoo;");
    
            _hGlobalLlMouseHook = IntPtr.Zero;
        }
    }
