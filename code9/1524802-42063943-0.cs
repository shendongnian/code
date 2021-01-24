    private void label_MouseClick(object sender, MouseEventArgs e)
    {
        if (sender == this.SelectedLabel) return;
        this.SelectedLabel.BackColor = Color.FromArgb(15, 34, 53); //lightercolor
        this.SelectedLabel= sender;
    }
    private void label_MouseLeave(object sender, EventArgs e)
    {
        if (sender == this.SelectedLabel) return; 
        ((Label)sender).BackColor = Color.FromArgb(15, 34, 53); //lightercolor
    }
    private void label_MouseEnter(object sender, EventArgs e)
    {
        ((Label)sender).BackColor = Color.FromArgb(9, 18, 28); //darkercolor
    }
