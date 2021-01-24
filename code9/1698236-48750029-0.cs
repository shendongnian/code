    class Report
    {
        public Guid Id { get; set;}
        public string Name { get; set;}
        // You might be able to replace this polymorphism
        public ReportType ReportType { get; set;}
        abstract Report Export();
    }
    class DownloadsInfoReport : Report
    {
        // Implement Export overload here
    }
