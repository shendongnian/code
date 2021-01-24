    string[] lines = File.ReadAllLines(openFile.FileName);
    for (int i = 0; i < lines.Length; i++) {
        lines[i] += ",";
    }
    File.WriteAllLines(openFile.FileName, lines);
