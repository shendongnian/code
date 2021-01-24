        private string _textFromMain, _textFromThreadByInvoke, _textFromThreadByCom;
        private delegate string GetClipboardInvoke(TextDataFormat textformat);
        private void SampleInvokeMethod()
        {
            GetClipboardInvoke invokerClipboard = new GetClipboardInvoke(Clipboard.GetText);
            _textFromThreadByInvoke = (string)this.Invoke(invokerClipboard, TextDataFormat.Text); // where this is a Form
            Thread.Sleep(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread sampleInvokeThread = new Thread(SampleInvokeMethod) { IsBackground = true };
            sampleInvokeThread.Start();
            Thread sampleComThread = new Thread(SampleComMethod) { IsBackground = true };
            sampleComThread.Start();
            Thread.Sleep(10000);
            _textFromMain = Clipboard.GetText(TextDataFormat.Text);
        }
        private void SampleComMethod()
        {
            _textFromThreadByCom = ClipboardCom.GetText();
            Thread.Sleep(1000);
        }
        public static class ClipboardCom
        {
            [DllImport("user32.dll")]
            static extern IntPtr GetClipboardData(uint uFormat);
            [DllImport("user32.dll")]
            static extern bool IsClipboardFormatAvailable(uint format);
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool OpenClipboard(IntPtr hWndNewOwner);
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool CloseClipboard();
            [DllImport("kernel32.dll")]
            static extern IntPtr GlobalLock(IntPtr hMem);
            [DllImport("kernel32.dll")]
            static extern bool GlobalUnlock(IntPtr hMem);
            const uint CF_UNICODETEXT = 13;
            public static string GetText()
            {
                if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
                    return null;
                if (!OpenClipboard(IntPtr.Zero))
                    return null;
                string data = null;
                var hGlobal = GetClipboardData(CF_UNICODETEXT);
                if (hGlobal != IntPtr.Zero)
                {
                    var lpwcstr = GlobalLock(hGlobal);
                    if (lpwcstr != IntPtr.Zero)
                    {
                        data = Marshal.PtrToStringUni(lpwcstr);
                        GlobalUnlock(lpwcstr);
                    }
                }
                CloseClipboard();
                return data;
            }
        }
