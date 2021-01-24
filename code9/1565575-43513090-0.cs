    private void panel_Click(object sender, EventArgs e)
    {
        Panel clickedPanel = sender as Panel;
        if ( clickedPanel != null )
        {
            if ( clickedPanel.BackColor == Color.Blue )
            {
                clickedPanel.BackColor = Color.Red;
            }
            else 
            {
                clickedPanel.BackColor = Color.Blue;
            }
        }
    }
