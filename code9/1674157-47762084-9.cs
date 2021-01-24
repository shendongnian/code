    public static String GetDescription(ReasonCode reasonCode)
    {
        if ((UInt32)reasonCode == 0)
            return "Verified";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Failed:");
        foreach (ReasonCode rc in Enum.GetValues(typeof(ReasonCode)).Cast<ReasonCode>())
        {
            if (rc == ReasonCode.None)
                continue;
            if (reasonCode.HasFlag(rc))
                sb.AppendLine(Enum.GetName(typeof(ReasonCode), rc) + " - " + GetEnumDescription(rc));
        }
        return sb.ToString();
    }
