    using (var reader = new PdfReader(sourcePdfPath))
    {
        foreach (var item in imgModellist.Where(x => x.Degree != 0).ToList())
        {          
            PdfDictionary page = reader.GetPageN(item.PageNumber);
            PdfNumber formerRotate = page.GetAsNumber(PdfName.ROTATE);
            if (formerRotate != null)
                page.Put(PdfName.ROTATE, new PdfNumber((formerRotate.IntValue + item.Degree) % 360));
            else
                page.Put(PdfName.ROTATE, new PdfNumber(item.Degree));
        }
        PdfStamper stamper = new PdfStamper(reader, new FileStream(tempOutputPdfPath, FileMode.Create));
        stamper.Close();
        stamper.Dispose();
        reader.Close();
    }
