    static void AppendIfDifferent(StringBuilder sb, string newValue,
            string oldValue, string label)
    {
        if(newValue != oldValue)
        {
            sb.AppendLine().Append(label).Append(" : ").Append(newValue);
        }
    }
