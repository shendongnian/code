    private void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
    {
        Control control = sender as Control;
        if (!VerticalScrollBarVisible(control))
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines;
            int numberOfPixelsToMove = numberOfTextLinesToMove * Convert.ToInt32(control.Font.Size);
            if (panel1.VerticalScroll.Value - numberOfPixelsToMove < panel1.VerticalScroll.Minimum)
                panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
            else if (panel1.VerticalScroll.Value - numberOfPixelsToMove > panel1.VerticalScroll.Maximum)
                panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            else
                panel1.VerticalScroll.Value -= numberOfPixelsToMove;
        }
    }
    
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private extern static int GetWindowLong(IntPtr hWnd, int index);
    public static bool VerticalScrollBarVisible(Control ctl) {
      int style = GetWindowLong(ctl.Handle, -16);
      return (style & 0x200000) != 0;
    }
