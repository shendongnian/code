    private string readFileContent(string pDocPath)
    {
       if(!System.IO.File.Exists(pDocPath))
       {
           Console.WriteLine("The file doesn't exist");
           return String.Empty;
       }
       var extractor = new TextExtractor(pDocPath);
       var txt = extractor.ExtractText();
       Console.WriteLine(txt);
       return txt;
    }
    
    static void Main(string[] args)
    {       
       var strDocPath = @"C:\Temp\yourWordDoc.doc";
       var strDocTxt = readFileContent(strDocPath);
    }
