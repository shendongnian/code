    public class PrinterModel   
        {
            public int Id { get; set; }
            public string printerName { get; set; }
        }
    public class MyModel
        {
            public List<PrinterModel> printers { get; set; } = new List<PrinterModel>();
            public string selectedId { get; set; } //This will be the id of what gets selected
        }
