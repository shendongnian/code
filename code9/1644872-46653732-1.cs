    public async void ConnectToDeviceService(IDevice device)
    {
        service = await device.GetServiceAsync(Guid.Parse(_UUIDS.SERVICE_UUID));
    
        infoCharacter = await service.GetCharacteristicAsync(Guid.Parse(_UUIDS.DEVICE_INFO_UUID));
        infoCharacter.ValueUpdated += (o, args) =>
        {
            var bytes = args.Characteristic.Value;
            Console.WriteLine("Characteristic Value: {0}", bytes);
            PrintByteArray(bytes);
        };
    
        await Task.Delay(1000);
        await infoCharacter.StartUpdatesAsync();
    }
