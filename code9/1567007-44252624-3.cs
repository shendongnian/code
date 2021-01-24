    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfficeOpenXml;
    using System.IO;
    namespace ExcelImageTests
    {
        [TestClass]
        public class EPPlusExcelImages
        {
            [TestMethod]
            public void FindsTwoDistinctImagesInFile()
            {
                var file = new FileInfo(@"C:\Users\path-to-my-file\sotest.xlsx");
                using (var package = new ExcelPackage(file))
                {
                    var workbook = package.Workbook;
                    var sheet = workbook.Worksheets[1];
                    Assert.AreEqual(2, sheet.Drawings.Count)
                    var drawingOne = sheet.Drawings[0];
                    var drawingTwo = sheet.Drawings[1];
                    // From returns the position of the upper left corner of the picture.
                    // To returns the position of the lower right corner.
                    Assert.IsTrue(drawingOne.From.Row < drawingTwo.From.Row);
                    Assert.IsTrue(drawingOne.From.Column < drawingTwo.From.Column);
                    Assert.IsTrue(drawingOne.To.Row < drawingTwo.To.Row);
                    Assert.IsTrue(drawingOne.To.Column < drawingTwo.To.Column);
                }
            }
        }
    }
