    public class LineItems : IInventoryReportItem
    {
        public string Title { get; set; }
        public int Quota => Contents?.Sum(x => x.Quota) ?? 0;
        public int TotalTicketsSold => Contents?.Sum(x => x.TotalTicketsSold) ?? 0;
        public int TotalUnitsSold => Contents?.Sum(x => x.TotalUnitsSold) ?? 0;
        public decimal TotalSalesAmount => Contents?.Sum(x => x.TotalSalesAmount) ?? 0;
        public readonly List<IInventoryReportItem> Contents;
        public LineItems(List<IInventoryReportItem> lineItems)
        {
            Contents = lineItems ?? new List<IInventoryReportItem>();
        }
        
    }
