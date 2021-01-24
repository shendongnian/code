    bool GpuEnabled = false;
    try
    {
        GpuEnabled = Alea.Device.Devices.Count() > 0;
    }
    catch
    {
        GpuEnabled = false;
    }
    Console.WriteLine(GpuEnabled.ToString());
