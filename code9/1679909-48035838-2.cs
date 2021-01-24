            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                thisViewControl = (ViewLifetimeControl)e.Parameter;
                mainViewId = ((App)App.Current).MainViewId;
                mainDispatcher = ((App)App.Current).MainDispatcher;
                // When this view is finally released, clean up state
                thisViewControl.Released += ViewLifetimeControl_Released;
            }
            private async void ViewLifetimeControl_Released(Object sender, EventArgs e)
            {
                ((ViewLifetimeControl)sender).Released -= ViewLifetimeControl_Released;
                // The ViewLifetimeControl object is bound to UI elements on the main thread
                // So, the object must be removed from that thread
                await mainDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ((App)App.Current).SecondaryViews.Remove(thisViewControl);
                });
                // The released event is fired on the thread of the window
                // it pertains to.
                //
                // It's important to make sure no work is scheduled on this thread
                // after it starts to close (no data binding changes, no changes to
                // XAML, creating new objects in destructors, etc.) since
                // that will throw exceptions
                Window.Current.Close();
            }
