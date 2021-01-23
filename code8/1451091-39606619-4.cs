    // Read in whole contents of file.
    var lines = File.ReadAllLines(Fullpath);
    // Alter the lines you want to.
    //Remove the last two rows (headers and data)
    if (lines.Length > 2) lines = lines.ToList().Take(lines.Length - 2).ToArray();
    
    // If lines contains 1 or more line in the file, replace any occurrence of OK, with NG.
    if (lines.Length >= 1) lines[lines.Length - 1] = lines[lines.Length - 1].Replace("OK", "NG");
    // Now write the contents of the file you have here in RAM back over the original file.
    File.WriteAllLines(Fullpath, lines);
