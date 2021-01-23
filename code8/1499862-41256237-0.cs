    private void txb_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textbox = sender as TextBox;
        if (!string.IsNullOrEmpty(textbox.Text.Trim()))
        {
            txb2.Focus(FocusState.Keyboard);
        }
    }
