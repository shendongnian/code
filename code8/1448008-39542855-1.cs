    private void ExcelExportValidation(DataTable dt, GridView Template)
    {
        try
        {
            bool isListRequired = false;
            List<string> groupCodeList = new List<string>(); ;
            Template.DataBind();
            if (Template.HeaderRow != null)
            {
               foreach (TableCell cell in Template.HeaderRow.Cells)
               {
                   if (cell.Text == "ActivityGroup_Code")
                   {
                       isListRequired = true;
                       groupCodeList = db.PMS_M_ActivityGroup.Select(a => a.ActivityGroup_Code).ToList();
                   }
                   dt.Columns.Add(cell.Text);
               }
                    
               var workbook = new XLWorkbook();
               var returnValue = workbook.AddWorksheet(dt);
               var worksheet = workbook.Worksheet(1);
               if (isListRequired)
               {
                   var tempDt = Helper.ConvertListToDataTable(groupCodeList);
                   tempDt.TableName = "Sheet1";
                   var returnValue2 = workbook.AddWorksheet(tempDt);
                   var worksheet2 = workbook.Worksheet(2);
                   int lastCellNo = groupCodeList.Count + 1;                       
                         worksheet.Column(5).SetDataValidation().List(worksheet2.Range("A2:A" + lastCellNo), true);                                               
                }
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=ExcelFormat.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Charset = "";
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    workbook.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendErrorToText(ex);
        }
    }
 
