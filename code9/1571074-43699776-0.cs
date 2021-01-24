        composite = (Windows.Storage.ApplicationDataCompositeValue)roamingSettings.Values["enabledDays"];
        ColumnDefinition column = new ColumnDefinition();
        column.Width = new GridLength(20, GridUnitType.Star);
        grid.ColumnDefinitions.Add(column);
        try {
            foreach (KeyValuePair<string, object> MonthBool in composite) {
                if ((bool)MonthBool.Value) {
                    column = new ColumnDefinition();
                    column.Width = new GridLength(100, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(column);
                }
            }
        }
        catch (Exception) {
        }
