    var frame = new Frame();
    frame.Navigate(typeof(MainPage), null);
    newWindow.Content = frame;
    newWindow.Activate();
    
    await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
        newAppView.Id,
        ViewSizePreference.UseHalf,
        currentAV.Id,
        ViewSizePreference.UseHalf);
    newAppView.TryResizeView(new Size { Width = rect.Width - 300, Height = rect.Height - 200 });
