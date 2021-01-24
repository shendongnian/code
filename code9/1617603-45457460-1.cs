    private void CheckIsNumeric(TextCompositionEventArgs e)
    {
        int result;
      string removedSpaces =  e.Text.Replace(" ","");
        if (!(int.TryParse(removedSpaces, out result)))
        {
           e.Handled = true;
           MessageBox.Show("!!!no content!!!", "Error", 
                           MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
