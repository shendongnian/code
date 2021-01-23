    public class DisabledRichTextBox : RichTextBox
    {
        private const int WmSetfocus = 0x07;
        private const int WmEnable = 0x0A;
        private const int WmSetcursor = 0x20;
        protected override void WndProc(ref Message m)
        {
            if (!(m.Msg == WmSetfocus || m.Msg == WmEnable || m.Msg == WmSetcursor))
            {
                base.WndProc(ref m);
            }
        }
    }
