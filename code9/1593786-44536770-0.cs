    private void ReadFile(FileInfo[] TXTFiles, out int totalLineCount, out bool result, out string footerContent)
     {
         string[] lines = File.ReadLines(TXTFiles[0].FullName);
         totalLineCount = lines.Count();
         result = lines.Last().StartsWith(fileFooterIdentify);
         footerContent = lines.Last();
     }
