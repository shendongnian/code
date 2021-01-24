        public FileContentResult CreatePdfFileContentResult()
        {
            var contentType = System.Net.Mime.MediaTypeNames.Application.Pdf;
            using (MemoryStream ms = new MemoryStream())
            {
                // Create an instance of the document class which represents the PDF document itself.
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                // Create an instance to the PDF file by creating an instance of the PDF 
                // Writer class using the document and the filestrem in the constructor.
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
    
                if (OnPdfMetaInformationAdd != null)
                    OnPdfMetaInformationAdd(document, DataSource);
    
                // Open the document to enable you to write to the document
                document.Open();
    
                if (OnPdfContentAdd != null)
                    OnPdfContentAdd(document, DataSource);
                else throw new NotImplementedException("OnPdfContentAdd event not defined");
    
                // Close the document
                document.Close();
                // Close the writer instance
                writer.Close();
    
                var fcr = new FileContentResult(ms.ToArray(), contentType); //NOTE: Using a File Stream Result will not work.
                fcr.FileDownloadName = FileName;                
                return fcr;
            }
        }
