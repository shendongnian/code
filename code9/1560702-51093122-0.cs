    [WMIClass("Win32_Processor")]
    public class Processor
    {
        public string Name { get; set; }
        [WMIProperty("NumberOfCores")]
        public int Cores { get; set; }
        public string Description { get; set; }
    }
