    var service = await connectedDevice.GetServiceAsync(Guid.Parse("<service-uuid-here>"));
    var characteristic = await service.GetCharacteristicAsync(Guid.Parse("<characteristic-uuid-here>"));
    
    // ...
    
    characteristic.WriteAsync(message);
    
