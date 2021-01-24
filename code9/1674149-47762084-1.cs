    public static String GetDescriptions(ReasonCode reasonCode)
    {       
        List<String> descriptions = new List<String>();
    
        foreach (ReasonCode rc in Enum.GetValues(typeof(ReasonCode)))
        {
            if (reasonCode.HasFlag(rc))
                descriptions.Add(rc.GetDescription());
        }
    
        return String.Join(" | ", descriptions.ToArray());
    }
