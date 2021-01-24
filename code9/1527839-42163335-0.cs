    public static void ChangeOrAddLine(string filePath, string newLine, string oldLine = "")
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
        using (StreamReader sr = new StreamReader(fs))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            List<string> lines = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            fs.Position = 0;
            bool lineFound = false;
            if (oldLine != "")
                for (int i = 0; i < lines.Count; i++)
                    if (lines[i] == oldLine)
                    {
                        lines[i] = newLine;
                        lineFound = true;
                        break;
                    }
            if (!lineFound)
                lines.Add(newLine);
            sw.Write(string.Join("\r\n", lines));
            fs.SetLength(fs.Position);
        }
    }
