        public void ExportToExcel(DataSet ds)
        {           
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    //Add DataTable as Worksheet.
                    wb.Worksheets.Add(dt);
                }
                //Export the Excel file.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Report.xlsx");                
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);                  
                    Response.Flush();                 
                    Response.End();
                }
            }
        }
