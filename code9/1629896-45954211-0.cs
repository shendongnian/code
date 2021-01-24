     protected override void OnNavigatedTo(NavigationEventArgs e)
     {
         base.OnNavigatedTo(e);
         SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
     }
     private void OnBackRequested(object sender, BackRequestedEventArgs e)
     {
         Frame rootFrame = Window.Current.Content as Frame;
         if (rootFrame.CanGoBack)
         { 
             var mediaelementposition = mediaelement.Position;
         } 
     }
     private void btngetposition_Click(object sender, RoutedEventArgs e)
     {          
         var mediaelementposition = mediaelement.Position;
     }
