    using (ShimsContext.Create())
    {
        Microsoft.Win32.Fakes.ShimRegistryKey.AllInstances.GetValueString = (key, valueName) =>
        { return "SomeValue"; };
        Microsoft.Win32.Fakes.ShimRegistryKey.AllInstances.OpenSubKeyStringBoolean = (key, subkey, write) =>
        {
            var openKey = new Microsoft.Win32.Fakes.ShimRegistryKey();
            openKey.NameGet = () => Path.Combine(key.Name, subkey);
            return openKey;
        };
        // Exercise the code under test that reads from the registry here. 
        // Make Assertions
    }
