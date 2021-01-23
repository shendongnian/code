    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern short GetKeyState(int keyCode);
    public const int KEY_PRESSED = 0x8000;
    public static bool IsKeyDonw(Keys key)
    {
        return Convert.ToBoolean(GetKeyState((int)key) & KEY_PRESSED);
    }
