             class createPOS
    {
     public  static PosExplorer explorer;
      public  static PosPrinter kitchenPrinter;
      public static void createPos()
      {
          explorer = new PosExplorer();
          DeviceInfo receiptPrinterDevice = explorer.GetDevice("PosPrinter", Properties.Settings.Default.KitchenPrinter); //May need to change this if you don't use a logicial name or use a different one.
          kitchenPrinter = (PosPrinter)explorer.CreateInstance(receiptPrinterDevice);
          kitchenPrinter.Open();
          kitchenPrinter.Claim(10000);
          kitchenPrinter.DeviceEnabled = true;
      }
          public static void Print(string text){
              if (kitchenPrinter.Claimed)
                  PrintTextLine(kitchenPrinter, text);  // kitchenPrinter.PrintNormal(PrinterStation.Receipt, text ); //Print text, then a new line character.
           }
          private static void PrintTextLine(PosPrinter printer, string text)
          {
              if (text.Length < printer.RecLineChars)
                  printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, then a new line character.
              else if (text.Length > printer.RecLineChars)
                  printer.PrintNormal(PrinterStation.Receipt, TruncateAt(text, printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest, no new line character (printer will probably auto-feed for us)
              else if (text.Length == printer.RecLineChars)
                  printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, no new line character, printer will probably auto-feed for us.
          }
          private static string TruncateAt(string text, int maxWidth)
          {
              string retVal = text;
              if (text.Length > maxWidth)
                  retVal = text.Substring(0, maxWidth);
              return retVal;
          }
      }
