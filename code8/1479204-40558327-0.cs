    class HotKeyMessageFilter : IMessageFilter
    {
        const int WM_KEYDOWN = 0x100;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                var keyCode = (Keys)m.WParam;
                if (keyCode == Keys.Tab && Form.ModifierKeys.HasFlag(Keys.Control))
                {
                    if (Form.ModifierKeys.HasFlag(Keys.Shift)) CycleActiveForm(-1);
                    else CycleActiveForm(1);
                }
            }
            return false;
        }
    }
