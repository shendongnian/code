    if (App.DetectPlatform() == Platform.WindowsPhone)
    {
        HardwareButtons.BackPressed += new EventHandler<BackPressedEventArgs>((s, a) =>
        {
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                a.Handled = true;
            }
        });
    }
