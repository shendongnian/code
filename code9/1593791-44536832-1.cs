    private void ReadFile(FileInfo[] TXTFiles, out int totalLineCount, out bool result, out string footerContent)
     {
         var content = File.ReadLines(TXTFiles[0].FullName);
         totalLineCount = content.Count();
         footerContent = content.Last();
         result = footerContent.StartsWith(fileFooterIdentify);
     }
