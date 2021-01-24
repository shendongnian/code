    TimeSpan t = TimeSpan.FromSeconds(newSecond);
    System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        mediaElement1.Position = TimeSpan.FromSeconds(newSecond);
    });
