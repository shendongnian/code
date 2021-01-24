        private async void manageBoardsDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            // at first, disable the autosuggest control
            autoSuggestBox.IsEnabled = false;
            var cts = new CancellationTokenSource();
            // do some async task
            // Set focus to another control 
            itemGridView.Focus(FocusState.Programmatic);
            // re-enable it
            autoSuggestBox.IsEnabled = true;
        }
