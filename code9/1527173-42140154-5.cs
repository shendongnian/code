    string xls = System.IO.File.ReadAllText("File.xls");
    string pattern = @"<xsl:value-of\s+select="(\w+)"\s*\/>";
    var lResult = Regex.Match(xls, pattern);
    if(lResult.Success)
        foreach( var iGroup in lResult.Groups)
            Console.WriteLine(iGroup);
