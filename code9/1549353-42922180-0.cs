    public void TextBoxEnumerateAndAction(Action<TextBox> execute)
    {
        // Get just the TextBoxes, no need of ugly casts...
        foreach(TextBox t in this.Controls.OfType<TextBox>())
        {
            execute?.Invoke(t);
            // This part is common to every textbox, so it can stay inside the
            // enumeration loop....
            btnReset.Enabled = !string.IsNullOrEmpty(t.Text)
        }
    }
