    //get Invoice PDF
    Byte[] pdf_bytes = Convert.FromBase64String(GetInvoicePDF(account, invoice, config));
    
    //Save a Debug Copy
    using( FileStream fs = File.Create("C:\\temp\\b4-invoice-" + invoice.id + ".pdf") )
    {
    	fs.Write(pdf_bytes, 0, (int)pdf_bytes.Length);
    	fs.Flush();
    	fs.Close();
    }
    
    MemoryStream msPDF = new MemoryStream();
    
    PdfReader reader = new PdfReader(pdf_bytes);
    Rectangle rect = reader.GetPageSize(1);
    
    
    using( PdfStamper stamper = new PdfStamper(reader, msPDF) )
    {
    	// modify the pdf content
    	PdfContentByte cb = stamper.GetOverContent(1);
    	//cb.SetColorStroke(iTextSharp.text.BaseColor.GREEN);
    	//cb.SetLineWidth(1f);
    	cb.SetColorFill(iTextSharp.text.BaseColor.WHITE);
    	cb.Rectangle(rect.GetLeft(0), rect.GetTop(0) - 250, 350, 250);
    	cb.Fill();
    	//cb.Stroke();
    }
    reader.Close();
    
    
    Byte[] pdf_bytes_out = msPDF.GetBuffer();
    
    using( FileStream fs = File.Create("C:\\temp\\invoice-" + invoice.id + ".pdf") )
    {
    	fs.Write(pdf_bytes_out, 0, (int)pdf_bytes_out.Length);
    	fs.Flush();
    	fs.Close();
    }
