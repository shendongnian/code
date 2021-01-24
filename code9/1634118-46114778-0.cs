        using (MemoryStream stream = new MemoryStream())
        {
            using (Document doc = new Document())
            {
                PdfCopy pdf = new PdfCopy(doc, stream);
                pdf.CloseStream = false;
                doc.Open();
                PdfReader reader = null;
                PdfImportedPage page = null;
                foreach (var file in Directory.GetFiles(sourceFolder))
                {
                    reader = new PdfReader(file);
                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }
                    pdf.FreeReader(reader);
                    reader.Close();
                }
            }
            using (FileStream streamX = new FileStream(destinationFile, FileMode.Create))
            {
                stream.WriteTo(streamX);
            }
        }
