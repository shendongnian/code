    private TaskCompletionSource<object> continueClicked;
    
    private async void Button_Click_1(object sender, RoutedEventArgs e) 
    {
      // Note: You probably want to disable this button while "in progress" so the
      //  user can't click it twice.
      await GetResults();
      // And re-enable the button here, possibly in a finally block.
    }
    
    private async Task GetResults()
    { 
      // Do lot of complex stuff that takes a long time
      // (e.g. contact some web services)
    
      // Wait for the user to click Continue.
      continueClicked = new TaskCompletionSource<object>();
      buttonContinue.Visibility = Visibility.Visible;
      await continueClicked.Task;
      buttonContinue.Visibility = Visibility.Collapsed;
    
      // More work...
    }
    
    private void buttonContinue_Click(object sender, RoutedEventArgs e)
    {
      if (continueClicked != null)
        continueClicked.TrySetResult(null);
    }
