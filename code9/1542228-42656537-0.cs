    private void cmdDevices_Click(object sender, System.EventArgs e) {
        DeviceManager1 = new DeviceManager();
        lbxDevices.Items.Clear();
        for (int I = 1; (I <= DeviceManager1.DeviceInfos.Count); I++) {
            lbxDevices.Items.Add(DeviceManager1.DeviceInfos(I).Properties["Name"].Value);
        }        
        if ((DeviceManager1.DeviceInfos.Count > 0)) {
            lbxDevices.SelectedIndex = 0;
        }        
    }
