    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        TextBox tb = sender as TextBox;
        string s = tb.Text + e.Text;
        byte b;
        if (!byte.TryParse(s, out b))
        {
            e.Handled = true;
            //play sound
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
