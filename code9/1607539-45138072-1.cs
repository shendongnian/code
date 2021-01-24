         private string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }
      
      public void printthis()
        {
            Duplexprint ds = new Duplexprint();
            string printername = GetDefaultPrinter();
            string errorMessage = string.Empty;
            ds.SetPrinterDuplex(printername, 2, out errorMessage);
            object Co = "1";
            object Pa = "1";
            object oT = true;
            object oF = false;
            if (Apptype == Applicationtypes.Word)
            {
                oDoc.PrintOut(ref oT, ref oF, ref obj, ref obj, ref obj,
                    ref obj, ref obj, ref Co, ref Pa, ref obj, ref oF, ref oT,
                    ref obj, ref obj, ref obj, ref obj, ref obj, ref obj);
            }
            else
            {
                xlWorkSheet.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            ds.SetPrinterDuplex(printername, 1, out errorMessage);
        }
