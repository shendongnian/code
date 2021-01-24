    public async Task LoadDevicesAsync() {
         using (XmlReader xmlRdr = new XmlTextReader(deviceConfigPath)) {
             var getdeviceListTasks = (from deviceElem in XDocument.Load(xmlRdr).Element("devices").Elements("device")
                     where (string)deviceElem.Attribute("type") == "mks247"
                     select Createmks247DeviceAsync(
                        (string)deviceElem.Attribute("ip"),
                        (string)deviceElem.Attribute("name"),
                        (string)deviceElem.Attribute("id"),
                        (bool)deviceElem.Attribute("autoconnect")
                         ));
            var devices = await Task.WhenAll(getdeviceListTasks);
            deviceList = devices.ToList();
        }
    }
