    public static String GetDescriptions(ReasonCode reasonCode)
    {       
        if (reasonCode == ReasonCode.None)
            return "Verified";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Failed:");
    
        foreach (ReasonCode rc in Enum.GetValues(typeof(ReasonCode)))
        {
            if (reasonCode.HasFlag(rc))
                sb.AppendLine(Enum.GetName(typeof(ReasonCode), rc) + " - " + rc.GetDescription());
        }
    
        return sb.ToString();
    }
