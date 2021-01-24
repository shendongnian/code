    public static String GetDescription(ReasonCode reasonCode)
    {
        if (reasonCode == ReasonCode.None)
            return "Verified";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Failed:");
        foreach (ReasonCode rc in Enum.GetValues(typeof(ReasonCode)).Cast<ReasonCode>())
        {
            if (rc == ReasonCode.None)
                continue;
            if (reasonCode.HasFlag(rc))
                sb.AppendLine(rc.ToString() + " - " + GetEnumDescription(rc));
        }
        return sb.ToString();
    }
