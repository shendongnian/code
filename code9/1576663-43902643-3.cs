    public class ReportModel
    {
            public OrderStatus OrderStatus { get; set; }
    
            public string OrderStatusDisplayText => DisplayAttributeHelper.ReadDisplay(OrderStatus);
    }
