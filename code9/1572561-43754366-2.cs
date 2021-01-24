    // Is bluetooth enabled?
    var bluetoothManager = new CoreBluetooth.CBCentralManager();
    if (bluetoothManager.State == CBCentralManagerState.PoweredOff) {
        // Does not go directly to bluetooth on every OS version though, but opens the Settings on most
        UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=Bluetooth")); 
    }
