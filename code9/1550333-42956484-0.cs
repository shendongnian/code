    public static CultureInfo __cultureInfo { get; set; }
    public static CultureInfo cultureInfo
    {
        get
        {
            if (__cultureInfo == null)
                __cultureInfo = new CultureInfo("pt-BR");
            return __cultureInfo;
        }
    }
