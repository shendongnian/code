    public static string[] PStoPDFArguments(string fileName) =>
        new string[]
        {
            "-dBATCH",
            "-dNOPAUSE",
            "-sDEVICE=pdfwrite",
            "-sPAPERSIZE=a4",
            "-dPDFSETTINGS=/prepress",
            $"-sOutputFile=\"{fileName}\"",
            "-"
        };
    
    //...
    public override void StdIn(out string input, int count)
    {
        var buffer = new char[count];
    
        Console.In.ReadBlock(buffer, 0, count);
    
        input = buffer[0] == '\0'
              ? null
              : new string(buffer);
    }
    //...
