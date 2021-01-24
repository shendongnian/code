    public static string ParseString(string input)
    {
        StringBuilder sb = new StringBuilder();
        bool skipNext = false; // used to skip spaces after commas
        foreach (char c in input)
        {
            if (!skipNext)
            {
                switch (c)
                {
                    case '(':
                        sb.Append("\n\t");
                        break;
                    case ',':
                        sb.Append("\n");
                        skipNext = true;
                        break;
                    case ')':
                        sb.Append("\n");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            else
            {
                skipNext = false;
            }
        }
        return sb.ToString();
    }
