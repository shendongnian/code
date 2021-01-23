    private void pClick(object sender, EventArgs e)
    {
        Panel panel = (sender as Panel);
        if (panel.BackColor == Color.Green) {
            panel.BackColor = Color.Red;
        } else if (panel.BackColor == Color.Red) {
            panel.BackColor = Color.Green;
        }
    }
