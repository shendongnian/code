    public string GetData(string filePath)
    {
        StringBuilder sb = new StringBuilder();
        bool flag = false;
        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                
                    if (line.Contains("OnError") || flag)
                {
                    sb.Append(line);
                    sb.AppendLine();
                    flag = true;
                }
                if (line.Contains("End Log"))
                {
                    flag = false;
                }
            }
            return sb.ToString();
        }
    }
