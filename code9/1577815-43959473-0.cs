     public static bool Print(string filepath, string printerName)
        {
            try
            {
                var doc = new PdfDocument();
                doc.LoadFromFile(filepath);
                doc.PrinterName = printerName;
                var psize = new PaperSize("Custom Paper Size", 417, 1007);
                doc.PrintDocument.DefaultPageSettings.PaperSize = psize;
                doc.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle180;
                
                doc.PrintDocument.Print();
                doc.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                // More code ...
            }
        }
