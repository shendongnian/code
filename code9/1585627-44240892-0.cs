    <TextBox x:Name="ValueTextBox" Grid.Column="0" Grid.RowSpan="2" VerticalContentAlignment="Center"
        Text ="{Binding Value}" PreviewTextInput="ValueTextBox_PreviewTextInput" />
----------
    private void ValueTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        decimal value;
        e.Handled = string.IsNullOrEmpty(e.Text) || !decimal.TryParse($"{ValueTextBox.Text}{e.Text}",
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out value);
    }
