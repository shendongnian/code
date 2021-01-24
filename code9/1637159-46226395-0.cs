    public class VersionMap
    {
        public String Install { get; private set; }
        public String Rollback { get; private set; }
    
        public VersionMap(String install, String rollback)
        {
            Install = install;
            Rollback = rollback;
        }
    }
    
    public String GetVersion(String version, String actionToRun)
    {
        var _8800PrinterData = new VersionMap("8.80.0(PrinterData)", "8.40.1(PrinterData)");
        var _8800CNA = new VersionMap("8.80.0(CNA)", "8.40.1(CNA)");
    
        var map = new Dictionary<string, VersionMap>
        {
            { "8.40.1(PrinterData)", _8800PrinterData },
            { "8.40.1(PrinterData)(Box)", _8800PrinterData },
            { "8.40.1(Box)", _8800PrinterData },
            { "8.40.1", _8800PrinterData },
            { "8.40.1(CNA)", _8800CNA },
            { "8.40.1(CNA)(Box)", _8800CNA },
            { "8.40.1(Box)",_8800CNA },
        };
    
        return actionToRun.Equals("Install") ? map[version].Install : map[version].Rollback;
    }
