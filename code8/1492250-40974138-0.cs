		public class JsonDataList
        {
            public List<JsonData> jsonData { get; set; }
        }
		public class JsonData
        {
            public int SalesOrderItemId { get; set; }
            public string AttachmentCode { get; set; }
            public string AttachmentName { get; set; }
            public int Qty { get; set; }
            public decimal UnitCost { get; set; }
            public decimal TotalCost { get; set; }
    
        }
