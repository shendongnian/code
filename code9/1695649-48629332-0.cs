    public class SalesOrder
    {
        public string loadStatus { get; set; }
        public string comments { get; set; }
        public string modifyDate { get; set; }
        public string custShipToID { get; set; }
        public string invoiceCount { get; set; }
        public string custBillToID { get; set; }
        public string invoiceAmount { get; set; }
        public string pickDate { get; set; }
        public string warehouse { get; set; }
        public string custName { get; set; }
        public string modifyTime { get; set; }
        public string loadID { get; set; }
        public string createTime { get; set; }
        public string createdBy { get; set; }
        public string custPONum2 { get; set; }
        public string modifiedBy { get; set; }
        public string SONum { get; set; }
        public string deliveryDate { get; set; }
        public string tripNumber { get; set; }
        public string custPONum { get; set; }
        public string status { get; set; }
        public string createDate { get; set; }
    }
    
    public class ResponseData
    {
        public List<SalesOrder> salesOrders { get; set; }
    }
    
    public class JsonObject
    {
        public string responseCPUTime { get; set; }
        public string response { get; set; }
        public string responseFor { get; set; }
        public ResponseData responseData { get; set; }
        public string responseMessage { get; set; }
    }
