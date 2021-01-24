    void DisableCloseButton(HWND hwnd)
    {
     EnableMenuItem(GetSystemMenu(hwnd, FALSE), SC_CLOSE,
                    MF_BYCOMMAND | MF_DISABLED | MF_GRAYED);
    }
    
    void EnableCloseButton(HWND hwnd)
    {
     EnableMenuItem(GetSystemMenu(hwnd, FALSE), SC_CLOSE,
                    MF_BYCOMMAND | MF_ENABLED);
    }
