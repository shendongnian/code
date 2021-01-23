    static class ClipboardHelper
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        public static bool SetText(string text)
        {
            IntPtr hWnd = GetOpenClipboardWindow(); // Gets the HWND of the window that currently owns the clipboard
            if (hWnd == null)   // If no window currently owns the clipboard, just go ahead and set the text.
            {
                System.Windows.Forms.Clipboard.SetText(text);
            }
            else
            {
                OpenClipboard(IntPtr.Zero);
                CloseClipboard();
                System.Windows.Forms.Clipboard.SetText(text);
            }
            return true;
        }
    }
