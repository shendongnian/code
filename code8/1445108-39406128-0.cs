            using (PdfDocument document = new PdfDocument())
            {
                //create pdf header
                document.Info.Title = "My barcode";
                document.Info.Author = "Me";
                document.Info.Subject = "Barcode";
                document.Info.Keywords = "Barcode, Ean13";
                document.Info.CreationDate = DateTime.Now;
                
                //create new pdf page
                PdfPage page = document.AddPage();
                page.Width = XUnit.FromMillimeter(210);
                page.Height = XUnit.FromMillimeter(297);
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    //make sure the font is embedded
                    var options = new XPdfFontOptions(PdfFontEmbedding.Always);
                    //declare a font for drawing in the PDF
                    XFont fontEan = new XFont("Code EAN13", 75, XFontStyle.Regular, options);
                    XTextFormatter tf = new XTextFormatter(gfx);
                    //create the barcode from string
                    gfx.DrawString(barcodeText, fontEan, XBrushes.Black, new XRect(15, 40, page.Width, page.Height), XStringFormat.TopLeft);     
                }
            }
