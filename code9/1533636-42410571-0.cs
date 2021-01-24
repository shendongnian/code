    private async void Dial_RotationChanged(RadialController sender,
                                            RadialControllerRotationChangedEventArgs args)
    {
        await ProjectionViewPageControl.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
        () =>
        {
            var thePage = (DetailPage)((Frame)Window.Current.Content).Content;
            thePage.ProjectionTest(args.RotationDeltaInDegrees);
        });
    }
