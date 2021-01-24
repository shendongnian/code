    [TestClass]
    public class ExcelWorksheetExtensionTests
    {
        private FileInfo _fileInfo;
        [TestInitialize]
        public void TestInitialize()
        {
            _fileInfo = new FileInfo(@"C:\Test.xlsx");
        }
        
        // This test may succeed...
        [TestMethod]
        public void TestGetRowIndexForExistingName()
        {
            using (var excelPackage = new ExcelPackage(_fileInfo))
            {
                var excelWorksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual(excelWorksheet.GetValue(1, 1), 6.0);
            }
        }
        // ...But this test will fail because TestInitialize re-runs too quickly.
        [TestMethod]
        public void TestGetRowIndexForMissingName()
        {
            using (var excelPackage = new ExcelPackage(_fileInfo))
            {
                var excelWorksheet = excelPackage.Workbook.Worksheets["Sheet1"];
                Assert.IsFalse(excelWorksheet.GetValue(1, 1) == null);
            }
        }
    }
