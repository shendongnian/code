    public string MeasureVoltage()
    {
         string Meas = "MEAS:VOLT:" + (ct == VoltageType.DC ? "DC?" : "AC?");
         return Measure(meas);
    }
    public string MeasureCurrent()
    {
        string Meas = "MEAS:CURR:" + (ct == CurrentType.DC ? "DC?" : "AC?");
        return Measure(meas);
    }
