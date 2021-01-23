    BitMiracle.Docotic.Pdf.PdfDocument pdfcontent=null;
    
    public static string GetText(string filename)
    {
    	if (PdfDocument.IsPasswordProtected(filename))
    	{
    		//method to show dialog for password
    		pass=getPassword()
    		using (pdfcontent = new PdfDocument(filename, pass))
    		{
    			return pdf.GetTextWithFormatting();
    		}
    	}
    	else
    	{
    		using (pdfcontent = new PdfDocument(filename))
    		{                    
    			return pdf.GetTextWithFormatting();                
    		}
    	}
    }
