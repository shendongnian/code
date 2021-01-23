        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == 121)  //F10 key
                {
                    try
                    {
                        UnhookWindowsHookEx(_hookID);//avoid ESC key to be captured
                        SetForegroundWindow(_handle);
                        SendKeys.Send("{ESC}");
                        _hookID = SetHook(_proc);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
