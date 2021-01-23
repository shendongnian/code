    var lines = File.ReadAllLines(Fullpath).ToList();
    // Remove as many lines as you'd like from the end
    if (lines.Count > 2)
    {
        lines.RemoveRange(lines.Count - 2, 2);
    }
    // Iterate backwards through the list until we've updated 2 (or more or less) lines
    var linesUpdated = 0;
    for (var i = lines.Count - 1; i >= 0 && linesUpdated < 2; i--)
    {
        if (lines[i].Contains("OK"))
        {
            lines[i] = lines[i].Replace("OK", "NG");
            linesUpdated++;
        }
    }
        
    File.WriteAllLines(Fullpath, lines.ToArray());
