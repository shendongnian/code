        [DllImport("user32.dll")]
        public static extern int SendMessage(
                          IntPtr hWnd,      // handle to destination window
                          uint Msg,       // message
                          IntPtr wParam,  // first message parameter
                          IntPtr lParam   // second message parameter
                          );
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_LBUTTONUP = 0x0202;       
        //This simulates a left mouse click
        public static void LeftMouseClick(IntPtr hwnd, uint xpos, uint ypos)
        {
            SendMessage(hwnd, WM_LBUTTONDOWN, new IntPtr(xpos), new IntPtr(ypos));
            SendMessage(hwnd, WM_LBUTTONUP, new IntPtr(xpos), new IntPtr(ypos));
        }
        private void send()
        {            
            LeftMouseClick(newGraphEditor.Handle, 10, 10);
        }
