    private void ValorInsTxtBox_KeyDown(Object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            InserirBtn_ClickAsync(sender, e);
            if (PosicaoInsTxtBox.IsEnabled)
            {
                PosicaoInsTxtBox.Focus(FocusState.Programmatic);
            }
            else
            {
                ValorInsTxtBox.Focus(FocusState.Programmatic);
            }
        }
        e.Handled = true;
    }
