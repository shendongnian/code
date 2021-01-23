    private void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
    {
        Control control = sender as Control;
        if (!NativeMethods.VerticalScrollBarVisible(control))
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
