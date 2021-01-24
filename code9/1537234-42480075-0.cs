    public class Data
    {
        public string Status { get; set; }
        public string Date { get; set; }
        public string Number { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public string TranId { get; set; }
        public string OPTId { get; set; }
        public string RefId { get; set; }
    }
    
    public class JsonResult
    {
        public string ResponseStatus { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string ErrorCode { get; set; }
        public Data Data { get; set; }
    }
