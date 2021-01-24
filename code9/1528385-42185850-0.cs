    private void App_BackRequested(object sender, BackRequestedEventArgs e)
    {
       if ( NavService.CanGoBack() )
       {
          NavService.GoBack();       
          e.Handled = true;
       }
    }
