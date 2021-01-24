    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ConnectedAnimation imageAnimation =
            ConnectedAnimationService.GetForCurrentView().GetAnimation("Image");
        imageAnimation?.TryStart(TargetElement);
    }
