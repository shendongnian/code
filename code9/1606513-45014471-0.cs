    private void AddToDisplay(StringBuilder sb, string title, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            if (sb.Length > 0)
                sb.Append(Environment.NewLine);
            sb.Append(title);
            sb.Append(value);
        }
    }
