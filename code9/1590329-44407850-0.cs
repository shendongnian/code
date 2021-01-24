    protected override void OnWindowCreated(WindowCreatedEventArgs args)
    {
        if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 4))
        {
            var capabilities = CompositionCapabilities.GetForCurrentView();
            var areEffectsSupported = capabilities.AreEffectsSupported();
            var areEffectsFast = capabilities.AreEffectsFast();
        }
        base.OnWindowCreated(args);
    }
