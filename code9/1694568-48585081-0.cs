    public class PurchaseOrderLine
    {
        public string lineNumber { get; set; }
        public string itemNumber { get; set; }
        public string itemDescription { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public bool isServiceBased { get; set; }
        public string taxIndicator1 { get; set; }
        public string taxIndicator2 { get; set; }
        public string unit { get; set; }
        public List<object> deliveryLines { get; set; }
        public List<object> supplierItems { get; set; }
        public bool isActive { get; set; }
    }
    
    public class PurchaseOrder
    {
        public string supplierId { get; set; }
        public string currencyCode { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public List<PurchaseOrderLine> purchaseOrderLines { get; set; }
        public string orderIdentifier { get; set; }
        public string supplierName { get; set; }
        public string orderType { get; set; }
        public bool isActive { get; set; }
    }
    
    public class RootObject
    {
        public List<PurchaseOrder> purchaseOrders { get; set; }
    }
