    private void PreviewNumInput(object sender, TextCompositionEventArgs e)
    {
        TextBox textBox = hourBox.Template.FindName("PART_TextBox", hourBox) as TextBox;
        string text = textBox.CaretIndex > 0 ? hourBox.Text + e.Text : e.Text + hourBox.Text;
        e.Handled = !IsPositiveNum(text);
    }
    private bool IsPositiveNum(string str)
    {
        int x;
        if (int.TryParse(str, out x) && x >= 0 && x <= 50)
            return true;
        return false;
    }
