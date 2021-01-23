        foreach (string line in lines)
        {
            if (line.Contains("()"))
            {
                MessageBox.Show(line + lineIndex);
            }
    lineIndex++;
        }
