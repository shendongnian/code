    for (int i = 19; i >= 0; i--)
    {
        var prop = Properties.Settings.Default.Properties["meas" + i];
        var value = prop.DefaultValue as string[];
        value[5] = "";
        prop.DefaultValue = value;
    }
    Properties.Settings.Default.Save();
