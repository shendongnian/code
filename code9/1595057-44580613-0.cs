    textBox.TextChanged += TextChanged_Event;
    private void TextChanged_Event(object sender, TextChangedEventArgs e)
    {
        if(Convert.ToInt32(e.Text) >= 300 && Convert.ToInt32(e.Text) <= 470)
        {
            e.Text = string.Empty;
            (or)
            //Do your logics here like perform validation operation
        }
    }
