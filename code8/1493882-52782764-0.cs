    //check printer is online
    private static bool IsOnline(ManagementBaseObject printer)
            {
                bool isOnlineprinter = true;
                PrinterNative.PrinterNative.PrinterNative printerNative = new PrinterNative.PrinterNative.PrinterNative();
                var PrinterName = printerNative.GetPrinterName();
                var PrinterNameProperty = printer.Properties["DeviceId"].Value.ToString();
                var ResultPrinter01 = printer.Properties["ExtendedPrinterStatus"].Value.ToString();
                var ResultPrinter02 = printer.Properties["PrinterState"].Value.ToString();
                if (PrinterNameProperty == PrinterName)
                {
                    //(no internet connection or printer switched off):PrinterState
                    if (ResultPrinter02 == "128"|| ResultPrinter02=="4096")
                    {
                        isOnlineprinter = false;
                    }
                    ////printer is initializing....
                    //if (ResultPrinter02 == "16")
                    //{
                    //    isOnlineprinter = false;
                    //}
                    //(no internet connection or printer switched off):ExtendedPrinterStatus
                    if (ResultPrinter01 == "7")
                    {
                        isOnlineprinter = false;
                    }
                }
                return isOnlineprinter;
             }
             
             
             
             
      //check PAPER OK OR OUT
    private static bool IspaperOK(ManagementBaseObject printer)
            {
                bool PaperOK = true;
                
                PrinterNative.PrinterNative.PrinterNative printerNative = new PrinterNative.PrinterNative.PrinterNative();
                var PrinterName = printerNative.GetPrinterName();
                var PrinterNameProperty = printer.Properties["DeviceId"].Value.ToString();
                var PaperStatus = printer.Properties["PrinterState"].Value.ToString();
                
                if (PrinterNameProperty == PrinterName)
                {
                    //(PrinterState)16 = Out of Paper
                    //(PrinterState)5 = Out of paper
                    //(PrinterState)4 = paperjam
                    //(PrinterState)144 = Out of paper
                    if ((PaperStatus == "5") || (PaperStatus == "16")||(PaperStatus=="144"))
                    {
                        PaperOK = false;
                    }
                }
                return PaperOK;
            }
            
            
            
    //check status printing
    private static bool Isprinting(ManagementBaseObject printer)
            {
                bool Isprintingnow = false;
                PrinterNative.PrinterNative.PrinterNative printerNative = new PrinterNative.PrinterNative.PrinterNative();
                var PrinterName = printerNative.GetPrinterName();
                var PrinterNameProperty = printer.Properties["DeviceId"].Value.ToString();
                var printing01 = printer.Properties["PrinterState"].Value.ToString();
                var printing02 = printer.Properties["PrinterStatus"].Value.ToString();
                if (PrinterNameProperty == PrinterName)
                {
                    //(PrinterState)11 = Printing
                    //(PrinterState)1024 = printing
                    //(PrinterStatus)4 = printing
                    if (printing01 == "11" || printing01 == "1024" || printing02=="4")
                    {
                        Isprintingnow = true;
                    }
                }
                return Isprintingnow;
            }
    //check for error (Printer)
     private static bool IsPrinterError(ManagementBaseObject printer)
            {
                bool PrinterOK = true;
                PrinterNative.PrinterNative.PrinterNative printerNative = new PrinterNative.PrinterNative.PrinterNative();
                var PrinterName = printerNative.GetPrinterName();
                var PrinterNameProperty = printer.Properties["DeviceId"].Value.ToString();
                var PrinterSpecificError = printer.Properties["PrinterState"].Value.ToString();
                var otherError = printer.Properties["ExtendedPrinterStatus"].Value.ToString();
                if (PrinterNameProperty == PrinterName)
                {
                    //(PrinterState)2 - error of printer
                    //(PrinterState)131072 - Toner Low
                    //(PrinterState)18 - Toner Low
                    //(PrinterState)19 - No Toner
                    if ((PrinterSpecificError == "131072")||(PrinterSpecificError == "18")||(PrinterSpecificError == "19")||(PrinterSpecificError == "2")||(PrinterSpecificError == "7"))
                    {
                        PrinterOK = false;
                    }
                    //(ExtendedPrinterStatus) 2 - no error
                    if (otherError=="2")
                    {
                        PrinterOK = true;
                    }
                    else
                    {
                        PrinterOK = false;
                    }
                }
                return PrinterOK;
            }
        //check Network or USB
private static bool IsNetworkPrinter(ManagementBaseObject printer)
        {
            bool IsNetwork = true;
            PrinterNative.PrinterNative.PrinterNative printerNative = new PrinterNative.PrinterNative.PrinterNative();
            var PrinterName = printerNative.GetPrinterName();
            var PrinterNameProperty = printer.Properties["DeviceId"].Value.ToString();
          
            var network = printer.Properties["Network"].Value.ToString();                   
            var local = printer.Properties["Local"].Value.ToString();
                        if (PrinterNameProperty == PrinterName)
                        {
                            if (network == "True")
                            {
                                IsNetwork = true;
                            }
                            if (network == "True" && local == "True")
                            {
                                IsNetwork = true;
                            }
                            if (local == "True" && network=="False")
                            {
                                IsNetwork = false;
                            }
                        }
            return IsNetwork;
        }
             
