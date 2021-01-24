    private void autoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.ChosenSuggestion != null && args.ChosenSuggestion is YourModelItem yourModelItem)
        {
            // When an item is selected...
        }
        else if (!string.IsNullOrEmpty(args.QueryText))
        {
            // When the search box is filled with something...
        }
    }
