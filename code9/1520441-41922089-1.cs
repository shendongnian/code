    using System.Runtime.InteropServices;
    ...
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
        UIntPtr dwExtraInfo);
    public const int KEYEVENTF_KEYUP = 0x0002;
    public const byte VK_MEDIA_PLAY_PAUSE = 0xB3;
    private void button_Click(object sender, RoutedEventArgs e)
    {
        // No flags indicate key down
        keybd_event(VK_MEDIA_PLAY_PAUSE, 0, 0, UIntPtr.Zero);
        keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
    }
