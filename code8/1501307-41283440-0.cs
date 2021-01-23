    public class AuditReportGroupingDataModelBase
    {
        public DateTime GroupTime { get; set; }
        public int CountryId { get; set; }
    }
    public class AuditReportGroupingDataModel : AuditReportGroupingDataModelBase
    {
        public int Count { get; set; }
    }
