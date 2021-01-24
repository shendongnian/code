    private int _HostName;
    public int HostName { get { return _HostName; } set { Set(ref _HostName, value); } }
    public void deviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var device = ((sender as ListView).SelectedItem as Device);
            //_ActiveDevice = device;
            HostName = device.HostName;
            DriveModel = device.DriveModel;
            DriveSN = device.DriveSN;
