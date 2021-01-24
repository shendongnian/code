            DataSet freeTable = new DataSet();
            freeTable = FoxDal.Instance.freeTable;
            FileInfo fileInfo = new FileInfo(@"E:\Test.xlsx");
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("table");
                ws.Cells["A1"].LoadFromDataTable(freeTable.Tables[0], true);
                pck.SaveAs(fileInfo);
            }
