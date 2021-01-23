    private void allTextboxes_Click(object sender, EventArgs e)
    {
        if ((sender as TextBox).Text == ((sender as TextBox).Tag as Button).Text)
        {
            (sender as TextBox).Text = "";
            ((sender as TextBox).Tag as Button).Visible = true;
        }
    }
