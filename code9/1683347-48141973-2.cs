    string[] lines = File.ReadAllLines(file);
    for(int i = 0; i < lines.Length; i++) {
        lines[i] = "('" + lines[i] + "')" + (i < lines.Length - 1 ? "," : "");
    }
    File.WriteAllLines(file, lines);
