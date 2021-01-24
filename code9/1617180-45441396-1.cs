    public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            >>>>>Timers.lastInteraction = DateTime.Now;
            Console.WriteLine((Keys)vkCode);
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
