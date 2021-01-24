            var target = new ExcelPackage(new System.IO.FileInfo("D:\\target.xlsx"));
            using (var source = new ExcelPackage(new System.IO.FileInfo("D:\\source.xlsm")))
            {
                foreach(var worksheet in source.Workbook.Worksheets)
                {
                    target.Workbook.Worksheets.Add(worksheet.Name, worksheet); 
                }
            }
            target.Save();
