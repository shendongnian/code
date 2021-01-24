    string[] lines = System.IO.File.ReadAllLines(batchfile);
    for (var i = 0; i < lines.Length; i++) {
        var line = lines[i];
        if (line.Contains("set image1=")) {
            lines[i] = line.Replace("set image1=", "set image1=c:\\1.jpg");
        } 
    }
    // Your lines-array have now been changed with your replacements
