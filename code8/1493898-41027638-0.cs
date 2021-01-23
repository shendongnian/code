    static void Main(string[] args)
            {
                List<string> filePaths = new List<string>();
                filePaths.Add("C:\\temp\\pe\\ACN-ONFBG-010-R-EN-ONT (1364).pdf");
                filePaths.Add("C:\\temp\\pe\\ACN-ONFBG-010-R-UN-NOR (1364).pdf");
                filePaths.Add("C:\\temp\\pe\\ACN-ONFBG-010-R-UN-SOU (1364).pdf");
                List<string> results = doit(filePaths);
                string stall = "stall";
            }
    
    
            private static List<string> doit(List<string> filePaths)
            {
                List<string> s = new List<string>();
                int z = 0;
                while (z < filePaths.Count())
                {
                    PdfReader pdfReader = new PdfReader(filePaths[z]);
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    for (int x = 1; x <= pdfReader.NumberOfPages; x++)
                    {
                        string currentText = "";
                        currentText = PdfTextExtractor.GetTextFromPage(pdfReader, x);
                        s.Add(currentText);
                    }
                    z++;
                    pdfReader.Close();
                }
                return s;
            }
