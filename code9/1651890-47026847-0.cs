    private void hourBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        IntegerUpDown senderTBox = sender as IntegerUpDown;
        TextBox tempTBox = senderTBox.Template.FindName("PART_TextBox", senderTBox) as TextBox;
        string text = tempTBox.CaretIndex > 0 ? senderTBox.Text + e.Text : e.Text + senderTBox.Text;
        if (senderTBox.Text.Length == 2)
        {
            senderTBox.Text = "";
            e.Handled = false;
            return;
        }
        e.Handled = !(IsPositiveNumInRange(text, 0, 99) && text.Length <= 2);
    }
    private void PreviewNumInput(object sender, TextCompositionEventArgs e)
    {
        TextBox textBox = hourBox.Template.FindName("PART_TextBox", hourBox) as TextBox;
        string text = textBox.CaretIndex > 0 ? hourBox.Text + e.Text : e.Text + hourBox.Text;
        e.Handled = !IsPositiveNumInRange(text, 0, 99);
    }
