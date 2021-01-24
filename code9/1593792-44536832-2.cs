    private void ReadFile(FileInfo[] TXTFiles, out int totalLineCount, out bool result, out string footerContent)
    {
        var content = File.ReadLines( TXTFiles[0].FullName );
        totalLineCount = 0;
        foreach ( var row in content )
        {
            totalLineCount++;
            footerContent = row;
        }
        result = footerContent.StartsWith( fileFooterIdentify );
    }
