    public ActionResult ExportData()
    {
        //....
        var rows=GetSummaryRows(2016);
        using (ExcelPackage package = new ExcelPackage())
        {
            var ws = package.Workbook.Worksheets.Add("My Sheet");
            //true generates headers
            ws.Cells["A1"].LoadFromCollection(rows, true);
            var stream = new MemoryStream();
            package.SaveAs(stream);
            string fileName = "myfilename.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            stream.Position = 0;
            return File(stream, contentType, fileName);
        }
    }
