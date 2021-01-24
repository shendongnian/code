    // Look for installed products containing 'Word' in their name and show their installed location
    foreach (var p in InstalledProduct.Enumerate())
    {
        try
        {
            if (p.InstalledProductName.Contains("Word"))                     
                Console.Out.WriteLine("{0} is intalled in {1}", p.GUID, p.InstallLocation);                    
        }
        catch (MSIException ex)
        {
            // Some products might throw an exception trying to access InstalledProductName propoerty.
        }
    }
