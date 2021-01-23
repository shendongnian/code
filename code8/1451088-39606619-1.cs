    // Read in whole contents of file.
    var lines = File.ReadAllLines(Fullpath);
    // Alter the lines you want to.
    // If lines contains 1 or more line in the file, replace any occurrence of OK, with NG.
    // Then do the same for the third to last line.
    if (lines.Length >= 1) lines[lines.Length - 1] = lines[lines.Length - 1].Replace("OK", "NG");
    if (lines.Length >= 3) lines[lines.Length - 3] = lines[lines.Length - 3].Replace("OK", "NG");
    
    // Now write the contents of the file you have here in RAM back over the original file.
    File.WriteAllLines(Fullpath, lines);
