             var ps = new PrinterSettings
             {
                 PrinterName = PhotosConfig.PhotosPrinterName,
                 Copies = (short)copies,
                 DefaultPageSettings =
                 {
                     Landscape = true,
                     Margins = new Margins()
                     {
                         Top = 0,
                         Bottom = 0,
                         Left = 0,
                         Right = 0
                     }
                 }
             };
             doc.OriginAtMargins = false;
             doc.PrinterSettings = ps;
             doc.PrintController = printController;
             doc.DefaultPageSettings.PaperSize = ps.PaperSizes[1]; var doc = new PrintDocument();
             var printController = new StandardPrintController();
             var ps = new PrinterSettings
             {
                 PrinterName = PhotosConfig.PhotosPrinterName,
                 Copies = (short)copies,
                 DefaultPageSettings =
                 {
                     Landscape = true,
                     Margins = new Margins()
                     {
                         Top = 0,
                         Bottom = 0,
                         Left = 0,
                         Right = 0
                     }
                 }
             };
             doc.OriginAtMargins = false;
             doc.PrinterSettings = ps;
             doc.PrintController = printController;
             doc.DefaultPageSettings.PaperSize = ps.PaperSizes[1];
             doc.PrintPage += (sender, args) =>
                 {
                     var i = Image.FromFile(imagePath);
                     args.Graphics.DrawImage(i, args.MarginBounds);
                 };
             doc.Print();
