    private bool clicked;
    
    private void bunifuImageButton1_MouseDown(object sender, EventArgs e)
    {
        bunifuImageButton1.BackColor = SystemColors.Control;
        clicked = true;
    }
    
    private void bunifuImageButton1_MouseUp(object sender, EventArgs e)
    {
        bunifuImageButton1.BackColor = SystemColors.HotTrack;
        clicked = false;
    }
    
    private void bunifuImageButton1_MouseLeave(object sender, EventArgs e)
    {
        bunifuImageButton1.BackColor = clicked ? SystemColors.HighLight : SystemColors.HotTrack;
    }
