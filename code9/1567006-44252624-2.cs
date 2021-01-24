    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NPOI.XSSF.UserModel;
    using System.IO;
    namespace ExcelImageTests
    {
        [TestClass]
        public class NpoiExcelImages
        {
            [TestMethod]
            public void FindsTwoDistinctImagesInFile()
            {
                XSSFWorkbook workbook;
                using (var file = new FileStream(@"C:\Users\path-to-my-file\sotest.xlsx", 
                    FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }
                var pictures = workbook.GetAllPictures();
                Assert.AreEqual(2, pictures.Count);
            }
        }
    }
