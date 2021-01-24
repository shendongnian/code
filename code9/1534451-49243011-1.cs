    if (wb != null)
                {
                    PrinterSettings settings = new PrinterSettings();
                    string defaultPrinter = settings.PrinterName;
                    Printer.SetDefaultPrinter("Microsoft Print to PDF");
                    wb.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER, null, null);
                    (new System.Action(() =>
                    {
                        Thread.Sleep(5000);
                        Printer.SetDefaultPrinter(defaultPrinter);
                    })).BeginInvoke(null, null);
                    
                }
 
