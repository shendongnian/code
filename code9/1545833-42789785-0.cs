    public class Rootobject
    {
        public int TotalItems { get; set; }
        public Paginginfo PagingInfo { get; set; }
        public int TotalPages { get; set; }
        public Datum[] Data { get; set; }
    }
    public class Paginginfo
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
    public class Datum
    {
        public int PurchaseOrderID { get; set; }
        public string PurchaseOrderGuid { get; set; }
        public User User { get; set; }
        public string PurchaseOrderReference { get; set; }
        public DateTime DateRaised { get; set; }
        public Supplier Supplier { get; set; }
        public Warehouse Warehouse { get; set; }
        public DateTime DateDue { get; set; }
        public string PurchaseOrderStatus { get; set; }
        public float DeliveryCost { get; set; }
        public float Subtotal { get; set; }
        public float TotalVat { get; set; }
        public float Total { get; set; }
        public Currency Currency { get; set; }
        public DateTime DateSent { get; set; }
        public Purchaseorderline[] PurchaseOrderLines { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
    }
    public class Warehouse
    {
        public string WarehouseName { get; set; }
        public string WarehouseGuid { get; set; }
        public int WarehouseID { get; set; }
    }
    public class Currency
    {
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
    }
    public class Purchaseorderline
    {
        public int PurchaseOrderLineID { get; set; }
        public string ProductSKU { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyReceived { get; set; }
        public string PurchaseOrderDetailsStatus { get; set; }
        public float SinglePrice { get; set; }
        public float LineVat { get; set; }
        public float LineTotal { get; set; }
        public int DeliveryStatusID { get; set; }
        public float QtyWrittenOff { get; set; }
        public int CartonQty { get; set; }
        public int AddedByUserID { get; set; }
        public int TotalUnitsOrdered { get; set; }
        public int TotalUnitsReceived { get; set; }
        public int TotalUnitsWrittenOff { get; set; }
        public string LineNotes { get; set; }
    }
