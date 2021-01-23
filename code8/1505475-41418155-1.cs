    private void PosicaoInsTxtBox_KeyDown(Object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            InserirBtn_ClickAsync(sender, e);
            PosicaoInsTxtBox.Focus(FocusState.Programmatic);
        }
        e.Handled = true;
    }
