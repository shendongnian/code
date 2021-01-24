    var printerList = PrinterSettings.InstalledPrinters.Cast<string>().ToList();
    bool printerFound = printerList.Any(p => p == printerName);
    if (printerFound)
    {
        //Do print stuff
    }
    else
    {
        //throw exception or send message
    }
