       using System.Management;
    
         foreach (string printername in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                        {
                            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printername);
        
                            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                            using (ManagementObjectCollection coll = searcher.Get())
                            {
                                try
                                {
                                    foreach (ManagementObject printer in coll)
                                    {
                                        foreach (PropertyData property in printer.Properties)
                                        {
                                            Console.WriteLine(string.Format("{0}: {1}", property.Name, property.Value));
                                        }
                                    }
                                }
                                catch (ManagementException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
    
    And you will get all the info of every printer, including name and IP
    
    
    If you want to get the printer IP from the name just use
    
        If(printer.Properties.Caption.Contains("Printer name")
        {
          return printer.Properties.PortName;
        }
    
    Otherwise, to obtain the ip from the name, reverse the process and search for the ip and return the name.
    
    
    For printers in the network, try this:
    
    using System.Management;
     
    private void Form1_Load(object sender, EventArgs e)
    {
    System.Management.ObjectQuery oquery = new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");
    System.Management.ManagementObjectSearcher mosearcher = new
    System.Management.ManagementObjectSearcher(oquery);
    System.Management.ManagementObjectCollection moc =
    mosearcher.Get();
     
    foreach (ManagementObject mo in moc)
    {
    System.Management.PropertyDataCollection pdc = mo.Properties;
    foreach (System.Management.PropertyData pd in pdc)
    {
    if ((bool)mo["Network"])
    {
    MessageBox.Show(String.Format("{1}", mo[pd.Name]));
    }
    }
    }
    }
     
    
     
    
    // To list printers installed on computer online/offline
    Code Snippet
    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
    {
    MessageBox.Show(printer);
    }
