    using (var reader = new PdfReader(sourcePdfPath))
    {
    	foreach (var item in imgModellist.Where(x => x.Degree != 0).ToList())
    	{          		
    		int rotation = (item.Degree + reader.GetPageRotation(item.PageNumber)) % 360;
    		PdfDictionary page = reader.GetPageN(item.PageNumber);
    		page.Put(PdfName.ROTATE, new PdfNumber(rotation));
    	}
    	PdfStamper stamper = new PdfStamper(reader, new FileStream(tempOutputPdfPath, FileMode.Create));
    	stamper.Close();
    	stamper.Dispose();
    	reader.Close();
    }	
