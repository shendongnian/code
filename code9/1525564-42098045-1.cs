    public class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public ActionResult Index()
    {
        var objectList = new List<TestObject>()
        {
            { new TestObject() {Id = 0, Name = "zero" } },
            { new TestObject() {Id = 1, Name = "one" } }
        };
    
        using (var ms = new MemoryStream())
        {
            using (var package = new ExcelPackage(ms))
            {
                var sheet = package.Workbook.Worksheets.Add("Sheet1");
                sheet.Cells["A1"].LoadFromCollection<TestObject>(objectList, true);
                return File(
                    package.GetAsByteArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "text.xlsx"
                );
            }
        }
    }
