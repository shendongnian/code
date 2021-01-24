            ViewLifetimeControl viewControl = null;
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // This object is used to keep track of the views and important
                // details about the contents of those views across threads
                // In your app, you would probably want to track information
                // like the open document or page inside that window
                viewControl = ViewLifetimeControl.CreateForCurrentView();
                viewControl.Title = "";
                // Increment the ref count because we just created the view and we have a reference to it                
                viewControl.StartViewInUse();
                var frame = new Frame();
                frame.Navigate(typeof(SecondaryPage), viewControl);
                Window.Current.Content = frame;
                // This is a change from 8.1: In order for the view to be displayed later it needs to be activated.
                Window.Current.Activate();
                ApplicationView.GetForCurrentView().Title = viewControl.Title;
                ((App)App.Current).SecondaryViews.Add(viewControl);
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewControl.Id, ViewSizePreference.Default, ApplicationView.GetForCurrentView().Id, ViewSizePreference.Default);
