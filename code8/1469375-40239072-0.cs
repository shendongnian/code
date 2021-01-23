    public ActionResult ExportToExcel()
        {
            Load l = new Load();
            List<Load> loadList = l.GetLoadsForGroup(date, groupID);
            var fileDownloadName = "fileName.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("New workbook");
            ws.View.ShowGridLines = true;
            ws.DefaultColWidth = 25;
            ws.Cells[1, 1].Value = "Order #";
            var currRow = 2;
            foreach (var load in loadList)
            {
                ws.Cells[2, 2].Value = load.LoadNumber;
            }
            Response.Clear();
            Response.ContentType = contentType;
            Response.AddHeader("content-disposition", "attachment; filename=\"" + fileDownloadName + "\"");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.Flush();
            Response.End();
            return View();
        }
