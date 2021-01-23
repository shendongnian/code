    public void AlternativeReplaceFreetextByTextbox(string InputPath, string OutputPath)
    {
        PdfName IT = new PdfName("IT");
        PdfName FREETEXTTYPEWRITER = new PdfName("FreeTextTypewriter");
        using (PdfReader Reader = new PdfReader(InputPath))
        {
            PdfDictionary Page = Reader.GetPageN(1);
            PdfArray Annotations = Page.GetAsArray(PdfName.ANNOTS);
            foreach (PdfObject Object in Annotations)
            {
                PdfDictionary Annotation = (PdfDictionary)PdfReader.GetPdfObject(Object);
                PdfName Intent = Annotation.GetAsName(IT);
                if (FREETEXTTYPEWRITER.Equals(Intent))
                {
                    // change annotation type to Textbox
                    Annotation.Put(IT, PdfName.FREETEXT);
                }
            }
            using (PdfStamper Stamper = new PdfStamper(Reader, new FileStream(OutputPath, FileMode.Create)))
            { }
        }
    }
