    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (AutoSuggestBoxRicercaOn)
        {
            AutoSuggestion.Visibility = Visibility.Visible;
            AutoSuggestBoxRicercaOn = false;
            await Task.Delay(TimeSpan.FromSeconds(0.05));
            bool setresult = AutoSuggestion.Focus(FocusState.Programmatic);
            System.Diagnostics.Debug.WriteLine("the setting focus result:" + setresult)
        }
        else
        {
            AutoSuggestion.Visibility = Visibility.Collapsed;
            AutoSuggestBoxRicercaOn = true;
        }
    }
