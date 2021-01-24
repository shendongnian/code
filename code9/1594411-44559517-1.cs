    <add key="Inputfile" value=”Path of pdf file where it is getting saved…”>
            <add key="Outputfile" value=”Path of pdf file where it has to be saved after getting password protected…”>   
    
    
            protected void passwordProtect(DateTime DateofBirth)
                    {
                        string yourpdf = ConfigurationManager.AppSettings["Inputfile"];
                        string pdfWithPasswordA = ConfigurationManager.AppSettings["Outputfile"];
                        string InputFileA = yourpdf;
                        string OutputFileA = pdfWithPasswordA;
            
                        using (Stream input = new FileStream(InputFileA, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (Stream output = new FileStream(OutputFileA, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                PdfReader reader = new PdfReader(input);
                                PdfEncryptor.Encrypt(reader, output, true, DateofBirth.ToString("yyyyMMdd"), "secret", PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_COPY);
                            }
                        } 
        
                   
        
                }
