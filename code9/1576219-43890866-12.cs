    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && dragLabel != null)
        {
            dragLabel.Location = e.Location;
            dataGridView1.ClearSelection();
        }
    }
