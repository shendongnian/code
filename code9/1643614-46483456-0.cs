    public enum VoltageType { AC, DC}
    public enum CurrentType { AC, DC}
    public string MeasureVoltage()
    {
        return Measure(MeasureType.Voltage);
    }
    public string MeasureCurrent()
    {
        return Measure(MeasureType.Current);
    }
        
    private enum MeasureType {Voltage, Current}
    private string Measure(MeasureType mt)
    {
        var what = (mt == Voltage) ? "VOLT" : "CURR";
        var type = ((mt == MeasureType.Voltage && vt == VoltageType.AC) || 
                    (mt == MeasureType.Current && ct == CurrentType.AC)) ? "AC?" : "DC?";
        
        string Meas = $"MEAS:{what}:{type}";
        io.PrintfAndFlush(Meas + "\n");
        Console.WriteLine(Meas);
        string response;
        io.Scanf("%s", out response);
        return response;
    }
