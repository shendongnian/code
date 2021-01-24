    // Get file content as string array.
    var lines = File.ReadAllLines(filePath);
    var sb = new StringBuilder(lines[lineIndex]);
    // Replacing character at given position
    sb[CharacterIndex] = 'A';
    lines[lineIndex] = sb.ToString();
    // Writing new content to file
    File.WriteAllLines(filePath, lines);
