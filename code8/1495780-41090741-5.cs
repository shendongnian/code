    StringBuilder sb = new StringBuilder();
    sb.AppendLine("[My Windows Form. . . . . . . . . . . . . . . . [X]]");
    sb.AppendLine("|GROUP A | GROUP B | GROUP C|");
    for (int i=0;i < names.Length; i++)
    {
        if((i+1) % 3 == 0)
        {
            sb.AppendLine($"|{names[i]}|");
        }
        else
        {
            sb.Append($"|{names[i]}");
        }
    }
    string result = sb.ToString();
