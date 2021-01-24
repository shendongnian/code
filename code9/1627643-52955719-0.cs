    public static class RichTextBoxUtils
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(System.IntPtr hWnd, int wMsg, System.IntPtr wParam, System.IntPtr lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        /// <summary>
        /// Scrolls the vertical scroll bar of a text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box base to scroll</param>
        public static void ScrollToBottom(this System.Windows.Forms.TextBoxBase tb)
        {
            if (System.Environment.OSVersion.Platform != System.PlatformID.Unix)
                SendMessage(tb.Handle, WM_VSCROLL, new System.IntPtr(SB_BOTTOM), System.IntPtr.Zero);
        }
    }
