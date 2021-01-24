     private int currentViewId = ApplicationView.GetForCurrentView().Id;
     private async void ShowNewView()
     {
         CoreApplicationView newView = CoreApplication.CreateNewView();
         int newViewId = 0;
         await newView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
         {
             Frame frame = new Frame();
             frame.Navigate(typeof(SecondPage), null);
             Window.Current.Content = frame;
             Window.Current.Activate();
             newViewId = ApplicationView.GetForCurrentView().Id;
         });
    
         await ApplicationViewSwitcher.SwitchAsync(newViewId, currentViewId, ApplicationViewSwitchingOptions.ConsolidateViews);
     }
