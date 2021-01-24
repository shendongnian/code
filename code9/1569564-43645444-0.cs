    Console.WriteLine("Please select one of the following printers:");
    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
    {
        Console.WriteLine($" - {i + 1}: {PrinterSettings.InstalledPrinters[i]}");
    }
            
    int printerIndex;
    do
    {
        Console.Write("Enter printer number (1 - {0}): ",
            PrinterSettings.InstalledPrinters.Count);
    } while (!int.TryParse(Console.ReadLine(), out printerIndex)
             || printerIndex < 1 
             || printerIndex > PrinterSettings.InstalledPrinters.Count);
    printDocument1.PrinterSettings.PrinterName = 
        PrinterSettings.InstalledPrinters[printerIndex - 1];
    
