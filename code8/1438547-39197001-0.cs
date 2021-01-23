    string[] lines = File.ReadAllLines("doc.txt");
    int i = Array.IndexOf(lines, "line2");
    if (i >= 0 && i < lines.Length - 1)
    {
        lines[i + 1] = "X";
        File.WriteAllLines("doc.txt", lines);
    }
