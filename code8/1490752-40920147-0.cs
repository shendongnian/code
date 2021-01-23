    using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("INMEMORYPDF.pdf", 1000000))
    {
        PDFPageMargins margins = new PDFPageMargins(10, 10, 10, 10);
        var document = new Document((_pageWidth > 540) ? PageSize.A4.Rotate() : PageSize.A4, margins.Left, margins.Right, margins.Top, margins.Bottom);
        using (MemoryMappedViewStream stream = mmf.CreateViewStream())
        {                       
                            
            PdfWriter.GetInstance(document, stream);
            document.Open();
            //MODIFY DOCUMENT
            document.Close();                    
        }
        byte[] content;
        using (MemoryMappedViewStream stream = mmf.CreateViewStream())
        {
            BinaryReader rdr = new BinaryReader(stream);
            content = new byte[mmf.CreateViewStream().Length];
            rdr.Read(content, 0, (int)mmf.CreateViewStream().Length);
        }
        return content;            
    }
