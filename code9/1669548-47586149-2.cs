    class InterceptedTextBox : System.Windows.Forms.TextBox
    {
      protected override void WndProc(ref Message m)
      {
        // WM_PASTE:
        if (m.Msg == 0x302 && Clipboard.ContainsText()) {
            this.Text = ConvertText(Clipboard.GetText());
            return;
        }
        base.WndProc(ref m);
      }
    }
