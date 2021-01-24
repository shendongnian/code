    public PosPrinter GetPrinterByName(System.Windows.Forms.Form mainForm, string printerName)
    {
      PosPrinter       printer  = null;
      PosExplorer      explorer = new PosExplorer(mainForm);
      DeviveCollection printers = explorer.GetDevices(DeviceType.PosPrinter);
      
      if (printers != null && printers.Count > 0)
      {
        for (int i = 0; i < printers.Count; i++)
        {
          if(0 == string.Compare(printerName, printers[i].ServiceObjectName))
          {
            printer = printers[i];
            break;
          }
        }
      }
      return printer;
    }
