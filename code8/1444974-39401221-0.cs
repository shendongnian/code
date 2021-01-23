    public override string ToString()
    {
        if(!string.IsNullOrEmpty(ConfigName))
            return ConfigName;
        return base.ToString();
    }
