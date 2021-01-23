    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        //Non-relevant converter stuff
        
        if ((System.Diagnostics.Process.GetCurrentProcess().ProcessName == "XDesProc")) return value; //use "devenv" instead of "XDesProc" in other versions 
        string Traduction = GetResourceManager().GetString(Key);
        //More non-relevant stuff, with proper return value
    }
