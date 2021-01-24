    private void CheckIsNumeric(TextCompositionEventArgs e)
    {
        int result;
        e.Text.Replace(" ","");
        if (!(int.TryParse(e.Text, out result)))
        {
           e.Handled = true;
           MessageBox.Show("!!!no content!!!", "Error", 
                           MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
