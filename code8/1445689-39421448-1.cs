        var lines = File.ReadLines(fileNameData, Encoding.Default);  
        int lineIndex=0;
        foreach (string line in lines)
        {
            if (line.Contains("()"))
            {
                MessageBox.Show(line + lineIndex);
            }
            lineIndex++;
        }
