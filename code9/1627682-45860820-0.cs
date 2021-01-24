    public class Turnover
            {
                public string DealerUserName { get; set; }
                public long CardNumber { get; set; }
                public string InvoiceNumber { get; set; }
                public decimal Amount { get; set; }
                public string Currency { get; set; }
                public string InvoiceDate { get; set; }
                public short SegmentNumber { get; set; }
                public List<product> Products{ get; set; }
            }
