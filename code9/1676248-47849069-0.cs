    private void Panels_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.None)
        {
            Control control = (Control)sender;
            if (control.Capture)
                control.Capture = false;
        }
    }
