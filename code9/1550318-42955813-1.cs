    private static void c_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Control control = (Control)sender;
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            control.Left = e.X + control.Left - MouseDownLocation.X;
            controlTop = e.Y + control.Top - MouseDownLocation.Y;
        }
    }
