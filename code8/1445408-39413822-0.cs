	    string pdffile = @"path\to\your\PDF\document.pdf";
        using (File pdf = new File(pdffile))
        {
            
            Document doc = pdf.Document;
            foreach (Page page in doc.Pages)
            {
                foreach (var a in page.Resources.Fonts.Keys)
                {
                    Console.WriteLine(page.Resources.Fonts[a].Name);
                }
		
	        }
        }
