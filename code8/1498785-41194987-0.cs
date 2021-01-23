    for (int Count = 11; Count <= 16; Count++)
    {
        var property = Properties.Settings.Default.GetType().GetProperty("_NW" + Count);
        var value = this.Controls["NW" + Count].Value;
        property.SetValue (Properties.Settings.Default, propertyValue, null);
    }
    
    Properties.Settings.Default.Save;
