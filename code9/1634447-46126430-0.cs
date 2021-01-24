    private void searchboxaddpart_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (args.SelectedItem is Item item)
        {
            sender.Text = item.desc;
        }
    }
    private void searchboxaddpart_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        if (args.ChosenSuggestion != null && args.ChosenSuggestion is Item item)
        {
            ViewModel.NavigationService.Navigate(typeof(ItemDetailPage),
                new Item
                {
                    Id = null,
                    Description = item.desc
                });
        }
    }
