    public bool GetBoolSetting(Settings setting)
    {
        var s = GetStringSetting(setting);
        if (string.IsNullOrEmpty(s))
            return false;
        return int.Parse(s) == 0 ? false : true;
    }
