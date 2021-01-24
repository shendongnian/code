    private void Form1_Load(object sender, EventArgs e)
    {
        // Get all serial (COM)-ports you can see in the devicemanager
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2",
            "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
            
        // Sort the items in the combobox 
        CmdBoxPort.Sorted = true;
        // Add all available (COM)-ports to the combobox
        foreach (ManagementObject queryObj in searcher.Get())
            CmdBoxPort.Items.Add(queryObj["Caption"]);
    }
    private void CmdBoxPort_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Set the right port for the selected item.
        // The portname is based on the "COMx" part of the string (SelectedItem)
        string item = CmdBoxPort.SelectedItem.ToString();
            
        // Search for the expression "(COM" in the "selectedItem" string
        if (item.Contains("(COM"))
        {
            // Get the index number where "(COM" starts in the string
            int indexOfCom = item.IndexOf("(COM");
            // Set PortName to COMx based on the expression in the "selectedItem" string
            // It automatically gets the correct length of the COMx expression to make sure 
            // that also a COM10, COM11 and so on is working properly.
            serialPort1.PortName = item.Substring(indexOfCom + 1, item.Length - indexOfCom - 2);
        }
        else
            return;
    }
