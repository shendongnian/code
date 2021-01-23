    @using OfficeOpenXml;
    <html>
        <body>
            <div id="page-wrapper">
                @{
                    // Change file extension to xlsm to test
                    string FileExtension = "xlsm";
                    ExcelPackage p = new ExcelPackage();
                    p.Workbook.Worksheets.Add("Worksheet Name");
                    int LatestWorksheetNumber = p.Workbook.Worksheets.Count;
                    ExcelWorksheet ws = p.Workbook.Worksheets[LatestWorksheetNumber];
                ws.Cells[1, 1].Value = "Test";
                p.Workbook.CreateVBAProject();
                //Generate A File
                Byte[] bin = p.GetAsByteArray();
                string filename = "filename";
                try
                {
                    //Download the file as an attachment
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.Cookies.Clear();
                    string ContentType = "";
                    if (FileExtension == "xlsx")
                    {
                        ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    }
                    else
                    {
                        ContentType = "application/vnd.ms-excel.sheet.macroEnabled.12";
                    }
                    Response.GetType();
                    Response.ContentType = ContentType;
                    Response.AddHeader("content-disposition", "attachment;  filename=" + filename + "." + FileExtension);
                    Response.BinaryWrite(bin);
                    Response.End();
                    <p>File Created</p>
                }
                catch (Exception e)
                {
                    <p>@e.Message</p>
                }
            }
        </div>
    </body>
    </html>
