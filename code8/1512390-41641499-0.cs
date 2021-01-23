        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        private void btnCopyToNotepad_Click(object sender, EventArgs e)
        {
            StartNotepad();
			Process[] notepads = null;
			while (notepads == null || notepads.Length == 0)
			{
				notepads = Process.GetProcessesByName("notepad");	
				Thread.Sleep(500);
			}
			
            if (notepads.Length == 0) return;
            if (notepads[0] != null)
            {
                Clipboard.SetText(textBox1.Text);
                SendMessage(FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null), 0x000C, 0, textBox1.Text);
            }
        }
        private static void StartNotepad() 
        {
            Process.Start("notepad.exe");
        }
