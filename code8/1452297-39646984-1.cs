    try
    {
        device =  await registryManager.AddDeviceAsync(new Device(dispositivo.Nombre));
     }
     catch (DeviceAlreadyExistsException)
     {
        device = await registryManager.GetDeviceAsync(dispositivo.Nombre);
     }
