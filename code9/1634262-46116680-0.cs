    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            label8.Text = "false";
            clicker.Enabled = false;
        }
    }
