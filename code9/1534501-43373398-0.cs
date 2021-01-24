    private int PageCount { get; set; }
    public void Print()
    {
	PageCount = 0;
	PrintDocument pd = new PrintDocument
	{
		// Define your settings
		PrinterSettings = {
			Duplex = Duplex.Horizontal,
			PrinterName =  ConfigurationManager.AppSettings["PrinterName"]
		}
	};
	Margins margins = new Margins(0, 0, 0, 0);
	pd.OriginAtMargins = true;
	pd.DefaultPageSettings.Margins = margins;
	pd.PrintPage += new PrintPageEventHandler(this.PrintPage);
	PrintPreviewDialog ppd = new PrintPreviewDialog();
	ppd.Document = pd;
	// Uncomment to show a Print Dialog box
	//if (ppd.ShowDialog() == DialogResult.OK)
		pd.Print();
	pd.Dispose();
    }
    
    private void PrintPage(object o, PrintPageEventArgs e)
    {
	PrintDocument p = (PrintDocument)o;
	p.DefaultPageSettings.Landscape = true;
	p.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
	p.DefaultPageSettings.PaperSize = new PaperSize("YourPaperSizeName", 340, 215);
	p.OriginAtMargins = true;
	o = p;
	e.PageSettings.PrinterSettings.DefaultPageSettings.Landscape = true;
	e.PageSettings.Landscape = true;
	
	// Do Print First Side (MAG ENCODE)
	if (PageCount == 0)
	{
		// Do Side 1 Stuff
		
		// If Two-Sided Printing: true
		e.HasMorePages = true;
    //If no more, set above to false and PageCount = 0, else...
		PageCount++;
	}
	else
	{
		// Do Print on Other Side
		// STUFF
		// STUFF
		// Since only two sides/card printing: false
		e.HasMorePages = false;
		PageCount = 0;
	}
    }
