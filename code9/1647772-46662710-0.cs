                var removableDevices = KnownFolders.RemovableDevices;
                var externalDevices = await removableDevices.GetFoldersAsync();
                var usbDriver = externalDevices.FirstOrDefault();
                var allProperties = usbDriver.Properties;
                IEnumerable<string> propertiesToRetrieve = new List<string> { "System.FreeSpace" };
                var storageIdProperties = await allProperties.RetrievePropertiesAsync(propertiesToRetrieve);
                var freeSpaceSize = storageIdProperties["System.FreeSpace"].ToString();
