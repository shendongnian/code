    private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        DatePicker dp = (sender as DatePicker);
        string text = dp.Text + e.Text;
        if (Regex.IsMatch(text, @"^\d{3}"))
        {
            e.Handled = true;
            DatePickerTextBox tb = dp.Template.FindName("PART_TextBox", dp) as DatePickerTextBox;
            tb.Text = Regex.Replace(text, @"(\d{2})(\d)", "$1.$2");
            tb.CaretIndex = tb.Text.Length;
        }
        else if (Regex.IsMatch(text, @"^(\d{2}\.\d{3})"))
        {
            e.Handled = true;
            DatePickerTextBox tb = dp.Template.FindName("PART_TextBox", dp) as DatePickerTextBox;
            tb.Text = Regex.Replace(text, @"(\d{2}\.\d{2})(\d)", "$1.$2");
            tb.CaretIndex = tb.Text.Length;
        }
    }
