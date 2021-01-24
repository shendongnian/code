    if (e.Result.Confidence.ToString() == "Medium" || e.Result.Confidence.ToString() == "High")
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
         {
             VisualStateManager.GoToState(this, "Playing", false);
         });
    }
