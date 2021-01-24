    private void empListBox_MouseEnter(object sender, MouseEventArgs e)
    {
        Mouse.Capture(empListBox, CaptureMode.SubTree);
    }
    private void empListBox_MouseLeave(object sender, MouseEventArgs e)
    {
        empListBox.ReleaseMouseCapture();
    }
