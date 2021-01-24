    class Hotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
        private IntPtr _hWnd;
    
        public Hotkey(IntPtr hWnd)
        {
            this._hWnd = hWnd;
        }
    
        public enum fsmodifiers
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008
        }
    
        public void RegisterHotkeys()
        {
            RegisterHotKey(this._hWnd, 1, (uint)fsmodifiers.Control, (uint)Keys.B);
        }
    
        public void UnregisterHotkeys()
        {
            UnregisterHotKey(this._hWnd, 1);
        }
    }
