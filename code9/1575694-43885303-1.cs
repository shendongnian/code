        using (PdfReader pdfReader = new PdfReader(input))
        {
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                PdfDictionary pageDictionary = pdfReader.GetPageN(page);
                pageDictionary.Remove(PdfName.CONTENTS);
            }
            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(output, FileMode.Create, FileAccess.Write)))
            {
            }
        }
