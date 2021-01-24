    public string MeasureVoltage()
    {
        return DoMeasurement($"MEAS:VOLT:{vt.ToString()}?");
    }
    
    public string MeasureCurrent()
    {
        return DoMeasurement($"MEAS:CURR:{ct.ToString()}?");
    }
    
    private string DoMeasurement(string Meas)
    {
        io.PrintfAndFlush(Meas + "\n");
        Console.WriteLine(Meas);
        string response;
        io.Scanf("%s", out response);
        return response;
    }
    public enum VoltageType { AC, DC }
    public enum CurrentType { AC, DC }
    
