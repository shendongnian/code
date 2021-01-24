    private class HiddenForm : Form
    {
        public HiddenForm()
        {
            SetParent(Handle, HWND_MESSAGE);
            AddClipboardFormatListener(Handle);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                // do stuff here like call event
            }
            base.WndProc(ref m);
        }
    }
