    public static void Copy(string val)
    {
        string[] lines = val.Split('\n');
        if (lines.Length == 0)
            $"echo {val} | clip".Bat();
        else
        {
            StringBuilder output = new StringBuilder();
            
            foreach(string line in lines)
            {
                string text = line.Trim();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    output.AppendLine(text);
                }
            }
            string tempFile = @"D:\tempClipboard.txt";
            File.WriteAllText(tempFile, output.ToString());
            $"type { tempFile } | clip".Bat();
        }
    }
