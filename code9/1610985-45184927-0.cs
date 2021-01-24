    public static void ChangeDateFormat(Excel.Range cell, string format, bool useLocale)
    {
        if (useLocale && !format.Contains("[$"))
        {
            format = "[$-800]" + format;
        }        
        SetProperty(cell, "NumberFormatLocal", new object[] { format });        
    }
    public static void SetProperty(object target, string name, params object[] args)
    {
        target.GetType().InvokeMember(name,
            BindingFlags.SetProperty |
            BindingFlags.Public |
            BindingFlags.Instance,
            null, target, args, new CultureInfo(1033));
    }
    
   
