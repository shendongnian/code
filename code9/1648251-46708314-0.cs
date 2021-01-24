        private void UpdatePDFAnnotation(string title, string body)
        {
            using (PdfReader pdfReader = new PdfReader(dataBuffer))
            {
                PdfDictionary pageDict = pdfReader.GetPageN(pageIndex);
                var annots = pageDict.GetAsArray(PdfName.ANNOTS);
                PdfDictionary annot = annots.GetAsDict(annotIndex);
                annot.Put(PdfName.T, new PdfString(title));
                annot.Put(PdfName.CONTENTS, new PdfString(body));
                using (MemoryStream ms = new MemoryStream())
                {
                    PdfStamper stamp = new PdfStamper(pdfReader, ms);    
                    stamp.Dispose();                
                    dataBuffer = ms.ToArray();
                }
            }
        }
