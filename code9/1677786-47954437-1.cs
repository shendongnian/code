    private void OnMediaPlayerFullWindowChanged(DependencyObject sender, DependencyProperty dp)
    {
        MediaPlayerElement mpe = (MediaPlayerElement)sender;
        
        if (mpe != null && dp == MediaPlayerElement.IsFullWindowProperty && !mpe.IsFullWindow)
        {
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }  
    }
