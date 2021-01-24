    class KeyHook {
        public static Action OnKey { get; set; }
        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                int vkCode = Marshal.ReadInt32(lParam);
                Console.WriteLine((Keys)vkCode);
                if (OnKey != null) {
                    OnKey();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
    ...
    BeatW.Timers timer = new BeatW.Timers();
    timer.startTimers();
    KeyHook kh = new KeyHook();
    KeyHook.OnKey = () => timer.lastInteraction = DateTime.Now;
