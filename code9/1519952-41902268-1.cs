    private void SaveSettings()
    {
        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        var compositeTest = new Windows.Storage.ApplicationDataCompositeValue();
        compositeTest["A"] = "A";
        localSettings.Values["Test"] = compositeTest;
    }
    private void BuildSettings()
    {
        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        var compositeTest = localSettings.Values["Test"] as Windows.Storage.ApplicationDataCompositeValue;
        var a = compositeTest["A"];
    }
