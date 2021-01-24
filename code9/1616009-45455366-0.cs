    internal class KeyboardInput
    {
        private readonly short _exitKey;
        private readonly uint[] _keyStates = new uint[short.MaxValue]; 
        public KeyboardInput(ConsoleKey exitKey)
        {
            _exitKey = (short) exitKey;
            // subscribe with empty delegates to prevent null reference check before call
            OnKeyDown += delegate { };
            OnKeyUp += delegate { };
        }
        public event Action<char, short> OnKeyDown;
        public event Action<char, short> OnKeyUp;
        public void Run()
        {
            var exitKeyPressed = false;
            var nRead = 0;
            var records = new INPUT_RECORD[10];
            var handle = GetStdHandle(STD_INPUT_HANDLE);
            while (!exitKeyPressed)
            {
                ReadConsoleInputW(handle, records, records.Length, ref nRead);
                for (var i = 0; i < nRead; i++)
                {
                    // process only Key events
                    if (records[i].EventType != KEY_EVENT) continue;
                    // process key state
                    ProcessKey(records[i].KeyEvent.wVirtualKeyCode, records[i].KeyEvent.bKeyDown,
                        records[i].KeyEvent.UnicodeChar);
                    // check for exit key press
                    if ((exitKeyPressed = records[i].KeyEvent.wVirtualKeyCode == _exitKey) == true) break;
                }
            }
        }
        private void ProcessKey(short virtualKeyCode, uint keyState, char key)
        {
            if (_keyStates[virtualKeyCode] != keyState)
                if (keyState == 1) OnKeyDown(key, virtualKeyCode);
                else OnKeyUp(key, virtualKeyCode);
            _keyStates[virtualKeyCode] = keyState;
        }
        #region Native methods
        private const short KEY_EVENT = 0x0001;
        private const int STD_INPUT_HANDLE = -10;
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool ReadConsoleInputW(IntPtr hConsoleInput, [Out] INPUT_RECORD[] lpBuffer, int nLength,
            ref int lpNumberOfEventsRead);
        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT_RECORD
        {
            [FieldOffset(0)] public readonly short EventType;
            //union {
            [FieldOffset(4)] public KEY_EVENT_RECORD KeyEvent;
            //[FieldOffset(4)]
            //public MOUSE_EVENT_RECORD MouseEvent;
            //[FieldOffset(4)]
            //public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
            //[FieldOffset(4)]
            //public MENU_EVENT_RECORD MenuEvent;
            //[FieldOffset(4)]
            //public FOCUS_EVENT_RECORD FocusEvent;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct KEY_EVENT_RECORD
        {
            public readonly uint bKeyDown;
            public readonly short wRepeatCount;
            public readonly short wVirtualKeyCode;
            public readonly short wVirtualScanCode;
            public readonly char UnicodeChar;
            public readonly int dwControlKeyState;
        }
        #endregion
    }
