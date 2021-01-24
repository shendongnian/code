    private void c_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        double num;
        e.Handled = double.TryParse(e.Text, out num);
        // if e.Text is a number, e.Handled will be true and num = e.Text
    }
