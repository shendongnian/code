    private static StringBuilder sb = new StringBuilder();
    public static void SqlLineGenerated(string line)
    {
        if (line.StartsWith("--"))
        {
            WriteDetailed(sb.ToString());
            sb = new StringBuilder();
        }
        else
        {
            sb.Append(query);
        }
    }
