    private void HelpKeyListen(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F1)
        {
            HelpContent.Content = new Help();
        }
    }
