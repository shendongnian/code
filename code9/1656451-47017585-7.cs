    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            (sender as TextBox)?.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
    }
