    private string activeLabel;
    private void btnArchives_Click(object sender, EventArgs e)
        {
            activeLabel = btnArchives.Text;
        }
    private void btnArchives_MouseEnter(object sender, EventArgs e)
        {
            lblArchives.BackColor = Color.FromArgb(9, 18, 28); //darkercolor
        }
    private void btnArchives_MouseLeave(object sender, EventArgs e)
    {
        if (activeLabel = btnArchives.Text)
        {
           lblArchives.BackColor = Color.FromArgb(9, 18, 28); //darkercolor
        }
        else
        {
           lblArchives.BackColor = Color.FromArgb(15, 34, 53); //lightercolor
        }
    }
