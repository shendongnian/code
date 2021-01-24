    public class LineItem : IInventoryReportItem
    {
        public LineItem(string title, int quota, int totalTicketsSold, int totalUnitsSold, int totalCheckedIn,
            decimal totalSalesAmount)
        {
            Title = title;
            Quota = quota;
            TotalUnitsSold = totalUnitsSold;
            TotalTicketsSold = totalTicketsSold;
            TotalCheckedIn = totalCheckedIn;
            TotalSalesAmount = totalSalesAmount;
        }
        
        public string Title { get; set; }
        public int Quota { get; }
        public int TotalTicketsSold { get; }
        public int TotalUnitsSold { get; }
        public int TotalCheckedIn { get; }
        public decimal TotalSalesAmount { get; }
    }
