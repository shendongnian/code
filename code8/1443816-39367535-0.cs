    PrintDocument pd = new PrintDocument();
    PrintController printController = new StandardPrintController();
    pd.PrintController = printController;
    pd.DefaultPageSettings.Margins = new Margins(0,0, 0, 0);
    pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 17);
    pd.PrintPage += (sndr, args) =>
    {
         System.Drawing.Image i = System.Drawing.Image.FromFile(@"C:\Users\EMOSI\Desktop\photo36.jpg");
         //Adjust the size of the image to the page to print the full image without loosing any part of the image.
         System.Drawing.Rectangle m = args.MarginBounds;
         //Logic below maintains Aspect Ratio.
         if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
         {
              m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width)-20;
              m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height) +5; // ajouter +
         }
         else
         {
              m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
         }
         //Calculating optimal orientation.
         pd.DefaultPageSettings.Landscape = m.Width > m.Height;
         //Putting image in center of page.
         m.Y = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Height - m.Height) / 2);
         m.X = (int)((((System.Drawing.Printing.PrintDocument)(sndr)).DefaultPageSettings.PaperSize.Width - m.Width) / 2) - 2; //chiffre bon
         args.Graphics.DrawImage(i, m);
    };
    pd.Print();
