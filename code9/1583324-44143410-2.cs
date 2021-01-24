    int citiesListIndex = 0;
    foreach (string countryname in countryNames)
    {
        //  This is the Path. You're binding to CitiesList[0]
        //  CitiesList[1], etc. 
        string propertyPath = $"CitiesList[{citiesListIndex}]";
    
        //  Pass path to constructor. 
        Binding bdg = new Binding(propertyPath);
    
        //  No-op
        //bdg.NotifyOnTargetUpdated = true;
    
        //  Is this a read-only column? If it's read-only, this is a no-op
        bdg.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    
        //  Is this a read-only column? If it's read-only, this is a no-op
        bdg.Mode = BindingMode.TwoWay;
        DataGridTextColumn newCityCol = new DataGridTextColumn();
        newCityCol.Header = countryname;
        newCityCol.Binding = bdg;
        dgr.Columns.Add(newCityCol);
        ++citiesListIndex;
    }
