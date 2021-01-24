    public string GetFromConfigWithVars(string key)
    {
        string value = ConfigurationManager.AppSettings[key];
        foreach (string var in value.Split('{', '}'))
        {
            string val = ConfigurationManager.AppSettings[var];
            value = value.Replace($"{{{var}}}", val);
        }
        return value;
    }
