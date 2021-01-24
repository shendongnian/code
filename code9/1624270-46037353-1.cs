        public static void DisableWPFTabletSupport()
        {
            // Get a collection of the tablet devices for this window.  
            TabletDeviceCollection devices = System.Windows.Input.Tablet.TabletDevices;
            if (devices.Count > 0)
            {
                // Get the Type of InputManager.
                Type inputManagerType = typeof(System.Windows.Input.InputManager);
                // Call the StylusLogic method on the InputManager.Current instance.
                object stylusLogic = inputManagerType.InvokeMember("StylusLogic",
                            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                            null, InputManager.Current, null);
                if (stylusLogic != null)
                {
                    //  Get the type of the device class.
                    Type devicesType = devices.GetType();
                    // Loop until there are no more devices to remove.
                    int count = devices.Count + 1;
                    while (devices.Count > 0)
                    {
                        // Remove the first tablet device in the devices collection.
                        devicesType.InvokeMember("HandleTabletRemoved", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, devices, new object[] { (uint)0 });
                        count--;
                        if (devices.Count != count)
                        {
                            throw new Win32Exception("Unable to remove real-time stylus support.");
                        }
                    }
                }
            }
        }
