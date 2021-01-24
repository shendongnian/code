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
