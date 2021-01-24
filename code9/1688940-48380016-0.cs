    var l = new []
            { new { Pattern = ".xsd", Value = 3010 }
            , new { Pattern = "_MAP_COPY.xml", Value = 3310 }
            };
    foreach (var p in l)
    {
        if (filename.EndsWith(p.Pattern))
        {
            return p.Value;
        }
    }
    // not found
