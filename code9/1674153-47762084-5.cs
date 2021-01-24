    public static String GetDescriptions(ReasonCode reasonCode)
    {       
        if (reasonCode.HasFlag(ReasonCode.None))
            return "Verified";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Failed:");
    
        foreach (ReasonCode rc in Enum.GetValues(typeof(ReasonCode)).Cast<ReasonCode>())
        {
            if (reasonCode.HasFlag(rc))
                sb.AppendLine(Enum.GetName(typeof(ReasonCode), rc) + " - " + Enums.GetDescription(rc));
        }
    
        return sb.ToString();
    }
