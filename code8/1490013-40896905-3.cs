    for (int i = 19; i >= 0; i--)
    {
        var prop = Properties.Settings.Default["meas" + i] as StringCollection;
        prop[5] = "";
    }
    Properties.Settings.Default.Save();
