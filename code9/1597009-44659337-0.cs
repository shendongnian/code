    public EventHandler TextBoxClick;
    public EventHandler ButtonClick;
    // Attach this handler to your TextBox.Click event
    private void TextBox_Click(object sender, EventArgs e)
    {
        if (TextBoxClick != null)
            TextBoxClick(sender, e);
    }
    // Attach this handler to your Button.Click event
    private void Button_Click(object sender, EventArgs e)
    {
        if (ButtonClick != null)
            ButtonClick(sender, e);
    }
