    private void ReadFile(FileInfo[] TXTFiles, out int totalLineCount, out bool result, out string footerContent)
     {
         var fileContents = File.ReadLines(TXTFiles[0].FullName);
         totalLineCount = fileContents.Count();
         result = fileContents.Last().StartsWith(fileFooterIdentify);
         footerContent = fileContents.Last();
     }
