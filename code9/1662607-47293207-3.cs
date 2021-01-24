    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    public void ExportToExcel(DataTable dt, string FileName)
    {
        //create a new byte array       
        byte[] bin;
        //create a new excel document
        using (ExcelPackage excelPackage = new ExcelPackage())
        {
            //create a new worksheet
            ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(FileName);
            //add the contents of the datatable to the excel file
            ws.Cells["A1"].LoadFromDataTable(dt, true);
            //auto fix the columns
            ws.Cells[ws.Dimension.Address].AutoFitColumns();
            //loop all the columns
            for (int col = 1; col <= ws.Dimension.End.Column; col++)
            {
                //make all columns just a bit wider, it would sometimes not fit
                ws.Column(col).Width = ws.Column(col).Width + 1;
                var cell = ws.Cells[1, col];
                //make the text bold
                cell.Style.Font.Bold = true;
                //make the background of the cell gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BFBFBF"));
                //make the header text upper case
                cell.Value = ((string)cell.Value).ToUpper();
            }
            //convert the excel package to a byte array
            bin = excelPackage.GetAsByteArray();
        }
        //clear the buffer stream
        Response.ClearHeaders();
        Response.Clear();
        Response.Buffer = true;
        //set the correct contenttype
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //set the correct length of the data being send
        Response.AddHeader("content-length", bin.Length.ToString());
        //set the filename for the excel package
        Response.AddHeader("content-disposition", "attachment; filename=\"" + FileName + ".xlsx\"");
        //send the byte array to the browser
        Response.OutputStream.Write(bin, 0, bin.Length);
        //cleanup
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
