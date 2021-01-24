    var box = (AutoSuggestBox)sender;
    box.IsSuggestionListOpen = true;
   
    var popups = VisualTreeHelper.GetOpenPopups(Window.Current);
    foreach (var popup in popups)
    {
        if (popup.Child is Rectangle bg)
        {
            bg.Tapped += Bg_Tapped;
            void Bg_Tapped(object s, TappedRoutedEventArgs args)
            {
                bg.Tapped -= Bg_Tapped;
                box.IsSuggestionListOpen = false;
                BrowseBySourceTopResultsListView.Focus(FocusState.Programmatic);
            }
        }
    }
