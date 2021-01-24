        /// <summary>
        /// Imports all pages from a list of documents.
        /// </summary>
    static void Variant1()
    {
      // Get some file names
      string[] files = GetFiles();
    &nbsp;
      // Open the output document
      PdfDocument outputDocument = new PdfDocument();
        &nbsp;
          // Iterate files
          foreach (string file in files)
          {
            // Open the document to import pages from it.
            PdfDocument inputDocument = PdfReader.Open(file,             PdfDocumentOpenMode.Import);
        &nbsp;
            // Iterate pages
            int count = inputDocument.PageCount;
            for (int idx = 0; idx < count; idx++)
            {
              // Get the page from the external document...
              PdfPage page = inputDocument.Pages[idx];
              // ...and add it to the output document.
              outputDocument.AddPage(page);
            }
          }
        &nbsp;
          // Save the document...
          const string filename = "ConcatenatedDocument1_tempfile.pdf";
          outputDocument.Save(filename);
          // ...and start a viewer.
          Process.Start(filename);
        }
    `
