    private void OnDataGridKeyDown(object sender, KeyEventArgs e)
    {
        if (Convert.ToChar(e.Key).IsLetter())
        {
            MessageBox.Show("Letter");
        }
        if (Convert.ToChar(e.Key).IsDigit())
        {
            MessageBox.Show("Number");
        }
    }
