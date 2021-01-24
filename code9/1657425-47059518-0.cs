    public override string GetValue(string key, string defaultValue)
    {
        SecStatusCode ssc;
        var found = GetRecord(key, out ssc);
        if (ssc == SecStatusCode.Success)
        {
            return found.ValueData.ToString();
        }
        return defaultValue;
    }
    private SecRecord GetRecord(string key, out SecStatusCode ssc)
    {
        var sr = new SecRecord(SecKind.GenericPassword);
        sr.Account = key;
        return SecKeyChain.QueryAsRecord(sr, out ssc);
    }
