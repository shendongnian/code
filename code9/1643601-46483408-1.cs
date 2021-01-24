    public string MeasureVoltage()
    {
        string Meas = "MEAS:VOLT:";
        if (vt == VoltageType.DC)
        {
            Meas += "DC?";
        }
        else
        {
            Meas += "AC?";
        }
        return PerformMeasurement(Meas);
    }
    public string MeasureCurrent()
    {
        string Meas = "MEAS:CURR:";
        if (ct == CurrentType.DC)
        {
            Meas += "DC?";
        }
        else
        {
            Meas += "AC?";
        }
        return PerformMeasurement(Meas);
    }
    private string PerformMeasurement(string Meas)
    {
        io.PrintfAndFlush(Meas + "\n");
        Console.WriteLine(Meas);
        string response;
        io.Scanf("%s", out response);
        return response;
    }
