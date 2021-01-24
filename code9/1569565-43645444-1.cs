    Console.WriteLine("Please select one of the following printers:");
    for (int i = 0; i < installedPrinters.Count; i++)
    {
        Console.WriteLine($" - {i + 1}: {installedPrinters[i]}");
    }
    int printerIndex;
    do
    {
        Console.Write("Enter printer number (1 - {0}): ", installedPrinters.Count);
    } while (!int.TryParse(Console.ReadLine(), out printerIndex)
             || printerIndex < 1 
             || printerIndex > installedPrinters.Count);
    printDocument1.PrinterSettings.PrinterName = installedPrinters[printerIndex - 1];
    
