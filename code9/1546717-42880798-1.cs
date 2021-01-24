    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var flyout = new Flyout()
        {
            Content = new Rectangle() { Fill = new SolidColorBrush(Colors.Red), Height = 100, Width = 100 }
        };
    
        if (UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse)
        {
            flyout.Placement = FlyoutPlacementMode.Bottom;
            flyout.ShowAt(DesktopBorder);
        }
    
        if (UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Touch)
        {
            flyout.Placement = FlyoutPlacementMode.Top;
            flyout.ShowAt(TabletBorder);
        }
    }
