        private BluetoothLEAdvertisementWatcher BTWatch = new BluetoothLEAdvertisementWatcher();
    
        private void Inits() 
            {
               BTWatch.Received += new TypedEventHandler<BluetoothLEAdvertisementWatcher, BluetoothLEAdvertisementReceivedEventArgs>(BtAddRx);
               BTWatch.Start();
            }
        
        private async void BtAddRx(BluetoothLEAdvertisementWatcher bw, BluetoothLEAdvertisementReceivedEventArgs args)
            {
                GattCommunicationStatus srslt;
                GattReadResult rslt;
                bw.Stop();//Stop this while inside.
                      
                device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                    if (device.DeviceInformation.Pairing.IsPaired == false)
                    {   
                        
                        /* Optional Below - Some examples say use FromIdAsync
                        to get the device. I don't think that it matters.   */            
                        var did = device.DeviceInformation.Id; //I reuse did to reload later.
                        device.Dispose();
                        device = null;
                        device = await BluetoothLEDevice.FromIdAsync(did);
                        /* end optional */
                        var handlerPairingRequested = new TypedEventHandler<DeviceInformationCustomPairing, DevicePairingRequestedEventArgs>(handlerPairingReq);
                        device.DeviceInformation.Pairing.Custom.PairingRequested += handlerPairingRequested;
                        log("Pairing to device now...."); 
                
                        var prslt = await device.DeviceInformation.Pairing.Custom.PairAsync(DevicePairingKinds.ProvidePin, DevicePairingProtectionLevel.None);                  
                        log("Custom PAIR complete status: " + prslt.Status.ToString() + " Connection Status: " + device.ConnectionStatus.ToString());
    
                        device.DeviceInformation.Pairing.Custom.PairingRequested -= handlerPairingRequested; //Don't need it anymore once paired.
                        
                      
                        if (prslt.Status != DevicePairingResultStatus.Paired)
                        { //This should not happen. If so we exit to try again.
                            log("prslt exiting.  prslt.status=" + prslt.Status.ToString());// so the status may have updated.  lets drop out of here and get the device again.  should be paired the 2nd time around?
                            bw.Start();//restart this watcher.
                            return;
                        }
                        else
                        {
                            // The pairing takes some time to complete. If you don't wait you may have issues. 5 seconds seems to do the trick.
                           
                            System.Threading.Thread.Sleep(5000); //try 5 second lay.
                            device.Dispose();
                           //Reload device so that the GATT services are there. This is why we wait.                     
                           device = await BluetoothLEDevice.FromIdAsync(did);
                           
                        }
     var services = device.GattServices;
    //then more code to finish it up.
    }
