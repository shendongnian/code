    ContextMenuStrip cms = new ContextMenuStrip();
    foreach (TCPIP ip in AssignedTCPIPentries) {
        mi = new ToolStripMenuItem(ip.IP + " - " + ip.Hostname);
        var ipSingleItemContextMenueItems = ip.SingleItemContextMenue.Items;     // get items
        
        for (int t = 0; t < ipSingleItemContextMenueItems.Count; t++) {
            mi.DropDown.Items.Add(ipSingleItemContextMenueItems[t]);
        }
        cms.Items.Add(mi);
    }
