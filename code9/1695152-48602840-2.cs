    private bool isMouseDown;
    private void bunifuImageButton1_MouseHover(object sender, EventArgs e)
    {
        bunifuImageButton1.BackColor = SystemColors.Highlight;
    }
    private void bunifuImageButton1_MouseDown(object sender, MouseEventArgs e)
    {
        bunifuImageButton1.BackColor = SystemColors.Control;
        isMouseDown = true;
    }
    
    private void bunifuImageButton1_MouseUp(object sender, MouseEventArgs e)
    {
        bunifuImageButton1.BackColor = SystemColors.HotTrack;
        isMouseDown = false;
    }
    
    private void bunifuImageButton1_MouseMove(object sender, MouseEventArgs e)
    {
        // If the mouse is down and the mouse is not over the button
        if (isMouseDown && !bunifuImageButton1.Bounds.Contains(e.Location))
        {
            bunifuImageButton1.BackColor = SystemColors.Highlight;
        }
    }
