    using (reader)
    {
        PdfDictionary page = reader.GetPageN(11);
        PdfArray annots = page.GetAsArray(PdfName.ANNOTS);
        for (int i = 0; i < annots.Size; i++)
        {
            PdfDictionary annotation = annots.GetAsDict(i);
            if (PdfName.LINK.Equals(annotation.GetAsName(PdfName.SUBTYPE)))
            {
                PdfArray d = annotation.GetAsArray(PdfName.DEST);
                if (d != null && d.Size == 5 && PdfName.XYZ.Equals(d.GetAsName(1)))
                    d.Set(4, new PdfNumber(0));
            }
        }
        using (var stream = new MemoryStream())
        {
            using (var stamper = new PdfStamper(reader, stream)) { }
            File.WriteAllBytes(outputFile, stream.ToArray());
        }
    }
