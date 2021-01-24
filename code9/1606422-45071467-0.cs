    UISettings uiSettings = new UISettings();
    uiSettings.AdvancedEffectsEnabledChanged += UiSettings_AdvancedEffectsEnabledChangedAsync;
    
    private async void UiSettings_AdvancedEffectsEnabledChangedAsync(UISettings sender, object args)
    {
        if (sender.AdvancedEffectsEnabled)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                //TODO: Apply Acrylic Accent
            });
        }
        else
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                //TODO: Reset background color
            });
        }
    }
