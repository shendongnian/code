    private void Button_Clicked(object sender, EventArgs e)
    {
        MessageEntry.Text = null;
    }
    
    private void MessageEntry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (MessageEntry.Text != null)
            SendButton.IsEnabled = true;
        else
            SendButton.IsEnabled = false;
    }
