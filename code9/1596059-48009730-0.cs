    private async void DisplayToggleDialog()
    {
       ContentDialog toggleDialog = new ContentDialog
       {
          Title = "You've Toggled the Item",
                  Content = "The Item is On",
                  CloseButtonText = "Ok"
       };
    
       ContentDialogResult result = await toggleDialog.ShowAsync();
    }
