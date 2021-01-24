    public static string FormatForSSN(String sb)
    {
        StringBuilder sb2 = new StringBuilder();
        if (sb.Length > 0) sb2.Append(sb.Substring(0, 1));
        if (sb.Length > 1) sb2.Append(sb.Substring(1, 1));
        if (sb.Length > 2) sb2.Append(sb.Substring(2, 1));
        if (sb.Length > 3) sb2.Append(sb.Substring(3, 1));
        if (sb.Length > 6) sb2.Append(sb.Substring(6, 1));
        if (sb.Length > 7) sb2.Append(sb.Substring(7, 1));
        if (sb.Length > 8) sb2.Append(sb.Substring(8, 1));
        return sb2.ToString();
    }
