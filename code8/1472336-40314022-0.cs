    var duplicateLines = new List<string> ();
    var acceptedLines = new List<string> ();
    
    for (var i = 0; i < lines.Length; i++) {
        var line = lines[i];
        if (!acceptedLines.Contains (line)) {
            acceptedLines.Add (line);
            continue;
        } else {
            duplicateLines.Add (line);
            if (lines.Length > i) {
                duplicateLines.Add (lines [++i]);
                continue;
            }
        }    
    }
