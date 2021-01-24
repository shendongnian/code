    System.Drawing.Printing.PageSettings pg=new System.Drawing.Printing.PageSettings();
    pg.Margins.Top = 0;
    pg.Margins.Bottom = 0;
    pg.Margins.Left = 0;
    pg.Margins.Right = 0;
    System.Drawing.Printing.PaperSize size = new PaperSize();
      // If you need A5 size then try:
    //size.RawKind = (int)PaperKind.A5;
    // pg.PaperSize = size;
    
    
    this.reportViewer1.SetPageSettings(pg);
    this.reportViewer1.RefreshReport();
