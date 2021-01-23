    foreach (var family in UIFont.FamilyNames)
    {
        System.Diagnostics.Debug.WriteLine($"{family}");
        foreach (var names in UIFont.FontNamesForFamilyName(family))
        {
            System.Diagnostics.Debug.WriteLine($"{names}");
        }
    }
