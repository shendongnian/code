            using (Document document = new Document())
            {
                using (PdfCopy copy = new PdfCopy(document, new FileStream(outFile, FileMode.Create)))
                {
                    document.Open();
                    PdfReader reader = new PdfReader(bytes);
                    for (int page = 0; page < reader.NumberOfPages;)
                    {
                        ++page;
                        copy.AddPage(copy.GetImportedPage(reader, page));
                    }
                }
            }
