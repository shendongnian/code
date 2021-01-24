    var replacements = new []
                       { new { Old = "*", New = string.Empty }
                       , new { Old = " ", New = "-" }
                       }
    foreach (var r in replacements)
    {
        Charseparated = Charseparated.Replace(r.Old, r.New);
    }
