    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceTotal { get; set; }
    }
    
    public void PrintJson()
    {
         List<Invoice> InvoiceList = new List<Invoice>();
         var outputObject = new { InvoiceList };
         InvoiceList.Add(new Invoice { InvoiceNumber = "SALES0000001", InvoiceDate = DateTime.UtcNow, InvoiceTotal = String.Format("{0:c}", "90000") });
         InvoiceList.Add(new Invoice { InvoiceNumber = "SALES0000002", InvoiceDate = DateTime.UtcNow, InvoiceTotal = String.Format("{0:c}", "60000") });
         var output1 = JsonConvert.SerializeObject(outputObject);
         var output2 = JsonConvert.SerializeObject(InvoiceList);
    }
