       string trimmedLine = "";
       string[] allLines = File.ReadAllLines(path);
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (string line in allLines)
            {
                if (!string.IsNullOrEmpty(line) && line.Length > 1)
                {
                    trimmedLine = line.TrimEnd(' ');
                    // use trimmedLine from here on...
