    var publisher = new BluetoothLEAdvertisementPublisher();
    publisher.Advertisement.ManufacturerData.Add(CreateData("T"));
    publisher.Advertisement.ManufacturerData.Add(CreateData("A"));
    publisher.Advertisement.ManufacturerData.Add(CreateData("S")); 
    publisher.start();
