    private void KeyUpTextBoxNumberCheck(object sender, KeyEventArgs e)
    {
        if (!IsDigitsOnly((sender as TextBox).Text))
        {
            (sender as TextBox).Text = "";
        }
    }
