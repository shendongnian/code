    private static LoadOptions GetLoadOptions(string path)
    {
        string extension = Path.GetExtension(path).ToUpperInvariant();
        switch (extension)
        {
            case ".XLSX":
            case ".XLSM":
            case ".XLTX":
            case ".XLTM":
                return LoadOptions.XlsxDefault;
            case ".XLS":
            case ".XLT":
                return GetLoadOptions(path, null);
            case ".ODS":
            case ".OTS":
                return LoadOptions.OdsDefault;
            case ".TAB":
            case ".TSV":
                return new CsvLoadOptions(CsvType.TabDelimited);
            case ".CSV":
                return LoadOptions.CsvDefault;
            default:
                return null;
        }
    }
    
    private static LoadOptions GetLoadOptions(string xlsPath, LoadOptions defaultOptions)
    {
        byte[] signature = new byte[8];
        using (var stream = File.OpenRead(xlsPath))
            stream.Read(signature, 0, 8);
    
        byte[] xlsSignature = new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 };
        if (signature.SequenceEqual(xlsSignature))
            return LoadOptions.XlsDefault;
    
        byte[] xlsxSignature = new byte[] { 0x50, 0x4B, 0x03, 0x04 };
        if (signature.Take(4).SequenceEqual(xlsxSignature))
            return LoadOptions.XlsxDefault;
    
        string firstLine = File.ReadLines(xlsPath)
            .First(line => !string.IsNullOrWhiteSpace(line)).TrimStart().ToUpperInvariant();
        if (firstLine.StartsWith("<!DOCTYPE") ||
            firstLine.StartsWith("<HTML") ||
            firstLine.StartsWith("<BODY"))
            return LoadOptions.HtmlDefault;
    
        return defaultOptions;
    }
