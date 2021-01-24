    private void NameTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete)
        {
            MessageBox.Show("delete pressed");
            e.Handled = true;
        }
    }
