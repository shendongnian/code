    public enum REPORT_TYPE
    {
        STORE,
        CUSTOMERS
    }
    public class ReportType
    {
        public string Name { get; set; }
        public REPORT_TYPE Type { get; set; }
    }
    public List<ReportType> ReportTypes { get; set; } = new List<ReportType>()
    {
        new ReportType() { Name = "Store", Type = REPORT_TYPE.STORE },
        new ReportType() { Name = "Customer", Type = REPORT_TYPE.CUSTOMERS }
    };
