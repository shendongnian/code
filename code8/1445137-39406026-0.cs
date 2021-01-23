    private void autosuggesttextchanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var filtered = hlist.Where(i => i.name.Contains(this.box.Text)).ToList();
                list.ItemsSource = filtered;
            }
        }
