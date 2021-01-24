    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        Settings.Default.Color0 = Settings.Default.Color1 = Settings.Default.Color2 = "";
        Settings.Default.Save();
        foreach (Button button in theGrid.Children.OfType<Button>())
        {
            BindingOperations.GetBindingExpression(button, Button.BackgroundProperty)?.UpdateTarget();
        }
    }
