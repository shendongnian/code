    using System.Management;
    
    private void btnGetPrinters_Click(object sender, EventArgs e) {
    
        // Use the ObjectQuery to get the list of configured printers.
    
        ObjectQuery oquery = new ObjectQuery("SELECT * FROM Win32_Printer");
     
        ManagementObjectSearcher mosearcher = new ManagementObjectSearcher(oquery);
     
        ManagementObjectCollection moc = mosearcher.Get();
     
        foreach (ManagementObject mo in moc)
        {
            PropertyDataCollection pdc = mo.Properties;
            
            foreach (System.Management.PropertyData pd in pdc)
            {
                if ((bool)mo["Network"])
                {
                    cmbPrinters.Items.Add(mo[pd.Name]);
                }
            }
        } 
    }
