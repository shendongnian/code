    public int GetIntSetting(Settings setting, int nullState)
    {
        var s = GetStringSetting(setting);
        if (string.IsNullOrEmpty(s) )
            return nullState;
        var result = 0;
        if(!int.TryParse(s,out result))
            return 0;
        return result;
    }
