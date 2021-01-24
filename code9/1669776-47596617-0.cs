    SendMessage(hwnd, WM_LBUTTONDOWN, 0, coords);
    SendMessage(hwnd, WM_LBUTTONDOWN, 0, coords);
    [DllImport("User32.dll")]
    public static extern Int32 SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);            // second message parameter
    public const int WM_LBUTTONDOWN = 0x201;
    public const int WM_LBUTTONUP = 0x202;
