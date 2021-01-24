    public class MyTextBox : TextBox
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        protected override bool ProcessKeyMessage(ref Message m)
        {
            if (m.Msg != WM_SYSKEYDOWN && m.Msg != WM_KEYDOWN)
            {
                return base.ProcessKeyMessage(ref m);
            }
            Keys keyData = (Keys)((int)m.WParam);
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.ShiftKey:
                    return false;
                default:
                    return base.ProcessKeyMessage(ref m);
            }
        }
    }
