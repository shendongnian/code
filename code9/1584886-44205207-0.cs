        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if ((nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && (nic.OperationalStatus == OperationalStatus.Up))
            {
                comboBox1.Items.Add(nic.Name);
            }
        }
