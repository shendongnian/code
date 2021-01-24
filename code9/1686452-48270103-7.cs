    public static class User32Wrapper
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(
            uint virtualKeyCode,
            uint scanCode,
            byte[] keyboardState,
            StringBuilder receivingBuffer,
            int bufferSize,
            uint flags);
    }
