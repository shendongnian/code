    private void XMLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (brisanjeDugme != null)
            brisanjeDugme.IsEnabled = true;
        if(XMLista != null && XMLista.SelectedItem != null)
            selected = XMLista.SelectedItem.ToString();
    }
