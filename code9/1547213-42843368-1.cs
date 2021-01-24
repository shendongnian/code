    var res = Regex.Replace(str, @"(?s)(\[nodots])(.*?)(\[/nodots])",
        m => string.Format(
            "{0}{1}{2}", 
                m.Groups[1].Value,                  // Restoring start delimiter
                m.Groups[2].Value.Replace(".",""),  // Modifying inner contents
                m.Groups[3].Value                   // Restoring end delimiter 
            )
        );
