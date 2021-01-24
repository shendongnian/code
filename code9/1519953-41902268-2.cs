    private void SaveSettings()
    {
        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        var compositeTest = (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["Test"];
        // Save test
        compositeTest["A"] = PropA;
        compositeTest["B"] = PropB;
        compositeTest["C"] = PropC;
        // Retrieve test
        var a = compositeTest["A"];
        var b = compositeTest["B"];
        var c = compositeTest["C"];
        localSettings.Values["Test"] = compositeTest;
    }
