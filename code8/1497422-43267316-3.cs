            PortableDeviceCollection c = new PortableDeviceCollection();
            c.Refresh();
            PortableDevice device = c.First();
            device.Root.RefreshFiles();
            PortableDeviceFolder internalstorageFolder = (PortableDeviceFolder)device.Root.Files.First();
