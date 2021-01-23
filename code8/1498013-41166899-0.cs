    private void button1_TextChanged(object sender, EventArgs e)
    {
        var button = sender as Button;
        button.Visible = (button.Text != String.Empty);
    }
