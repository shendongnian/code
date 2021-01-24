    public bool? GetBoolSetting(Settings setting)
    {
        var s = GetStringSetting(setting);
        if (string.IsNullOrEmpty(s))
            return null;
        return int.Parse(s) == 0 ? false : true;
    }
