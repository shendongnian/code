    IEnumerable<TestObject> objectList = new List<TestObject>()
    {
        { new TestObject() {Id = 0, Name = "zero" } },
        { new TestObject() {Id = 1, Name = "one" } }
    };
    var values = new List<object[]>()
    { 
        new string[] { "one", "two" }, 
        new string[] { "three", "four" }
    };
    
    using (var package = new ExcelPackage())
    {
        var sheet = package.Workbook.Worksheets.Add("Sheet1");
        // note second parameter gives you headings
        sheet.Cells["A1"].LoadFromCollection<TestObject>(objectList, true);
        sheet.Cells["A4"].LoadFromArrays(values);
        File.WriteAllBytes(OUTPUT, package.GetAsByteArray());
    }
