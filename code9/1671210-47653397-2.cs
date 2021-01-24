    XNamespace ns = "DeviceInfoCollection";
    var devices = from e in xDoc.Root.Descendants(ns + "DeviceInfo")
               select new DeviceInfo
               {
                   SerialID = (string)e.Element(ns + "SerialID"),
               };
    foreach(var device in devices)
    {
        Console.WriteLine(device.SerialID);
    }
