            public static void PrintXPSToDefaultPrinter(string FilePath)
            {
                try
                {
                    // Create the print dialog object and set options
                    PrintDialog pDialog = new PrintDialog();
                    pDialog.PageRangeSelection = PageRangeSelection.AllPages;
                    pDialog.UserPageRangeEnabled = true;
                    
                    FileInfo file = new FileInfo(FilePath);
                    XpsDocument xpsDocument = new XpsDocument(FilePath, FileAccess.ReadWrite);
                    FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
    
                    pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, file.Name);
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine("The file is being used by some other process.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occured : {0}", ex.Message);
                }
            }
