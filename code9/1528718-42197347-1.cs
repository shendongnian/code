    private double previousScrollPosition = -1;
    
    private async void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        try
        {
            ScrollViewer Scroller = sender as ScrollViewer;
    
            var verticalOffsetValue = Scroller.VerticalOffset;
            var maxVerticalOffsetValue = Scroller.ExtentHeight - Scroller.ViewportHeight;
            if (previousScrollPosition < Scroller.VerticalOffset)
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                 () =>
                 {
                     previousScrollPosition = Scroller.VerticalOffset;
                     SearchSP.Visibility = Visibility.Collapsed;
                 });
            }
            else if (previousScrollPosition > Scroller.VerticalOffset + 70 || Scroller.VerticalOffset == 0)
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                 () =>
                 {
                     previousScrollPosition = Scroller.VerticalOffset;
                     SearchSP.Visibility = Visibility.Visible;
                 });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error in scrollviewer changed " + ex.Message);
        }
    }
    
