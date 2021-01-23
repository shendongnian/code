    using (System.IO.MemoryStream memIn = new MemoryStream(pdfin))
    using (System.IO.MemoryStream memOut = new MemoryStream())
    {
    	byte[] image = null;
    
    	using (System.IO.MemoryStream memWatermark = new MemoryStream(pdfWatermark))                                        
    	using (var document = PdfiumViewer.PdfDocument.Load(memWatermark))
    	{
    	   using (var ms = new MemoryStream())
    	   {
    		   document.Render(0, 300, 300, true).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    		   image = ms.ToArray();
    	   }
    	}
    
    	PdfReader reader = new PdfReader(memIn);
    	int n = reader.NumberOfPages;
    	PdfStamper stamper = new PdfStamper(reader, memOut);
    
    
    	// transparency
    	PdfGState gs1 = new PdfGState();
    	gs1.StrokeOpacity = 0.4f;
    	gs1.FillOpacity = 0.2f;
    
    	// properties
    	PdfContentByte over;
    	iTextSharp.text.Rectangle pagesize;
    	float x, y;
    
    
    	stamper.FormFlattening = true;
    	stamper.FreeTextFlattening = true;
    
    	iTextSharp.text.Rectangle wmSize = reader.GetPageSize(1);
    	int wmRotation = reader.GetPageRotation(1);
    
    	// image watermark
    	var img = iTextSharp.text.Image.GetInstance(image);
    	float w = img.ScaledWidth;
    	float h = img.ScaledHeight;
    
    
    	using (Document doc = new Document(wmSize))
    	{
    		PdfWriter writer = PdfWriter.GetInstance(doc, memOut);
    		doc.Open();
    
    		PdfImportedPage currentPage;
    		for (int i = 1; i <= reader.NumberOfPages; i++)
    		{
    			pagesize = reader.GetPageSizeWithRotation(i);
    			over = writer.DirectContent;
    
    			currentPage = writer.GetImportedPage(reader, i);
    			if (wmRotation == 90 || wmRotation == 270)
    				over.AddTemplate(currentPage, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
    			else
    				over.AddTemplate(currentPage, 1f, 0, 0, 1f, 0, 0);
    
    			x = (pagesize.Left + pagesize.Right) / 2;
    			y = (pagesize.Top + pagesize.Bottom) / 2;
    			over.SaveState();
    			over.SetGState(gs1);
    
    			var pageRotation = reader.GetPageRotation(i);
    			if (pageRotation == 90 || pageRotation == 270)
    			{
    				if (pageRotation == 90)
    				{
    					img.RotationDegrees = 180f;
    					img.SetAbsolutePosition(0, 0);
    					over.AddImage(img);
    				}
    				else
    				{
    					img.RotationDegrees = -90f;
    					img.SetAbsolutePosition(-(y / 2), (x / 2));
    					over.AddImage(img);
    				}
    			}
    			else
    				over.AddImage(img, w, 0, 0, h, x - (w / 2), y - (h / 2));
    
    			over.RestoreState();
    
    			// now move to following page
    			if (i < reader.NumberOfPages)
    			{
    				doc.NewPage();
    			}
    		}
    
    		// flush writer but leave the stream open!
    		writer.Flush();
    		writer.CloseStream = false;
    	}
    
    	memOut.Position = 0;
    	if (memOut.Length > 0)
    	{
    		pdfout = new byte[memOut.Length];
    		pdfout = memOut.ToArray();
    		done = true;
    	}
    
    	stamper.Close();
    	reader.Close();
    }
