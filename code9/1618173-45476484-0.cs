     public class Invoice
    {
        public int Number { get; set; }
        public string SupplierName { get; set; }
        public int Amount { get; set; }
    }
    public sealed class ExportInvoicesCsvMap : CsvClassMap<Invoice>
    {
        public ExportInvoicesCsvMap()
        {
            Map(i => i.Number).Index(0).Name("Number");
            Map(i => i.SupplierName).Index(1).Name("Supplier Name");
        }
    }
            var config = new CsvConfiguration();
            config.RegisterClassMap<ExportInvoicesCsvMap>();
            List<Invoice> list = new List<Invoice>();
            list.Add(new Invoice
            {
                Number = 1,
                SupplierName = "SN",
                Amount=7
            });
            using (var sw = new StreamWriter(@"test.csv"))
            {
                var _csvWriter = new CsvWriter(sw, config);
                IEnumerable records = list;
                _csvWriter.WriteRecords(records);
            }
