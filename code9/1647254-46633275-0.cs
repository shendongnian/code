           try
            {
                CoreApplicationView Nv= CoreApplication.CreateNewView();
                var z = CoreApplication.MainView;
                int id= 0;
                await 
        Nv.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Frame frame = new Frame();
                    frame.Navigate(typeof(page));
                    Window.Current.Content = frame;
                    // You have to activate the window in order to show it later.
                    Window.Current.Activate();
                    id= ApplicationView.GetForCurrentView().Id;
                });
                bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
            }
            catch (Exception eee)
            {
                Windows.UI.Popups.MessageDialog errorBox =
                   new Windows.UI.Popups.MessageDialog("Couldn't Create New 
              Window: " + eee.Message);
                await errorBox.ShowAsync();
            }
