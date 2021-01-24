    //Instantiate document objects
    Document destinationPdfDocument = new Document();
    Document sourcePdfDocument = new Document();
    //Load source files which are to be merged
    var filesFromDirectory = Directory.GetFiles(dataDir, "*.pdf");
    for (int i = 0; i < filesFromDirectory.Count(); i++)
    {    
     if (i == 0)
     {
     destinationPdfDocument = new Document(filesFromDirectory[i]);
     }
     else
     {
     // Open second document
     sourcePdfDocument = new Document(filesFromDirectory[i]);
     // Add pages of second document to the first
     destinationPdfDocument.Pages.Add(sourcePdfDocument.Pages);
     //** I need to check size of destinationPdfDocument over here to limit the size of resultant PDF**
     MemoryStream ms = new MemoryStream();
     destinationPdfDocument.Save(ms);
     long filesize = ms.Length;
     ms.Flush();
     // Compare the filesize in MBs
     if (i == filesFromDirectory.Count() - 1)
     {
      destinationPdfDocument.Save(dataDir + "PDFOutput_" + i + ".pdf");
     }
     else if ((filesize / (1024 * 1024)) < 200)
     continue;
     else
     {
      destinationPdfDocument.Save(dataDir + "PDFOutput_" + i.ToString() + ".pdf");
      destinationPdfDocument = new Document();
     }
     }
     }
