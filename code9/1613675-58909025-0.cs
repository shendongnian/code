            var fileName = new FileInfo(@"C:\Temp\sample101.xlsx");
            //lets open the copy 
            using (var excelFile = new ExcelPackage(fileName))
            {
               // select 1st worksheet
               var worksheet = excelFile.Workbook.Worksheets[0];
               // copy from A9:L9 
               var cellRange = worksheet.Cells["A9:L9"];
               // copy to destination A10:L10
               var destination = worksheet.Cells["A10:L10"];
               cellRange.Copy(destination);
               // save file
               excelFile.Save();
            }
