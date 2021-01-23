    var lines = File.ReadAllLines(path);
    if (lines.Length > 0)
    {
      lines[lines.Length - 1] = lines[lines.Length - 1].Replace("OK", "NG");
    }
    File.WriteAllLines(path, lines);
