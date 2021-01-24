    public static void ExtractTextFromPdf(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        {
            StringBuilder text = new StringBuilder();
    
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }
            string lines = "";
           using(var file = new StreamWriter(path2))
           {
              file.WriteLine(lines);
              file.Close();
           }      
    
        }
    }
