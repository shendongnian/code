    public interface IInventoryReportItem
    {
        string Title { get; set; }
        int Quota { get; }
        int TotalTicketsSold { get; }
        int TotalUnitsSold { get; }
        decimal TotalSalesAmount { get; }
    }
