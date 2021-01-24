    private void RandomLabel_MouseEnter(object sender, EventArgs e)
    {
        if (sender is TextBox)
        {
            ((TextBox)sender).Font = new Font(((TextBox)sender).Font, FontStyle.Bold);
        }
        else if (sender is PictureBox)
        {
            ((PictureBox)sender).Font = new Font(((PictureBox)sender).Font, FontStyle.Bold);        
        }
        else
        {
            throw new InvalidArgumentException("sender");
        }
    }
