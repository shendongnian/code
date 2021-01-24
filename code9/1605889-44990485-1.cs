    private void SetUpHook()
    {
        Logger.Debug("Setting up global mouse hook");
        // Create an instance of HookProc.
        _globalLlMouseHookCallback = LowLevelMouseProc;
        _hGlobalLlMouseHook = NativeMethods.SetWindowsHookEx(
            HookType.WH_MOUSE_LL,
            _globalLlMouseHookCallback,
            Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
            0);
        if (_hGlobalLlMouseHook == IntPtr.Zero)
        {
            Logger.Fatal("Unable to set global mouse hook");
            throw new Win32Exception("Unable to set MouseHook");
        }
    }
