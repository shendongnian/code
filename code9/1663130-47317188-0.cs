    public string insertlines(string s, int i)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(s);  // create the string
        for (int c = 0; c < i; c++)
        {
            sb.AppendLine(""); // add a line each time
        }
        return sb.ToString();
    }
