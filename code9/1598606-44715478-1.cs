    var replacements = new []
                       { new { Old = "*", New = string.Empty }
                       // all your other replacements, removed for brevity
                       , new { Old = " ", New = "-" }
                       }
    foreach (var r in replacements)
    {
        Charseparated = Charseparated.Replace(r.Old, r.New);
    }
