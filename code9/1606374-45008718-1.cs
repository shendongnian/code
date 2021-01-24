    private void ResizablePanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isResizeMode = true;
        }
    }
    private void ResizablePanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (isResizeMode)
        {
            this.Size = new Size(e.X, e.Y);
        }
    }
    private void ResizablePanel_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isResizeMode = false;
        }
    }
