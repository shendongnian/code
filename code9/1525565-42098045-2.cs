    class TestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    IEnumerable<TestObject> objectList = new List<TestObject>()
    {
        { new TestObject() {Id = 0, Name = "zero" } },
        { new TestObject() {Id = 1, Name = "one" } }
    };
    string ExcelName = "test.xlsx";
    string ZipName = "test.zip"; 
    
    public ActionResult DotnetZip()
    {
        using (var stream = new MemoryStream())
        {
            using (ZipFile zip = new ZipFile())
            {
                using (var pkgStream = new MemoryStream())
                {
                    using (var package = new ExcelPackage(pkgStream))
                    {
                        var sheet = package.Workbook.Worksheets.Add("Sheet1");
                        sheet.Cells["A1"].LoadFromCollection<TestObject>(objectList, true);
    
                        zip.AddEntry(ExcelName, package.GetAsByteArray());
                        zip.Save(stream);
                        return File(
                            stream.ToArray(),
                            System.Net.Mime.MediaTypeNames.Application.Zip,
                            ZipName
                        );
                    }
                }
    
            }
        }
    }
