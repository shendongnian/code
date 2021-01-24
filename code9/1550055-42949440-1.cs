    private void DataGrid_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            TextCompositionManager.StartComposition(new TextComposition(InputManager.Current, this, Environment.NewLine));
        }
    }
