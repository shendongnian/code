    public abstract class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // You might be able to replace this polymorphism
        public ReportType ReportType { get; set; }
        public abstract Report Export();
    }
    public class DownloadsInfoReport : Report
    {
        public object FileFormat { get; set; }
        public bool IsInCloud { get; set; }
        public string DownloadedThroughLink { get; set; }
        public override Report Export()
        {
            // Specific Export logic here
        }
    }
    public class ClicksInfoReport : Report
    {
        public object UserClicking { get; set; }
        public int TimesClickedOnSamePage { get; set; }
        public override Report Export()
        {
            // Specific Export logic here
        }
    }
