    public void ProcessRequest (HttpContext context)
    {
        //create dumy data, or in youre case the data form somewhere else
        DataTable table = new DataTable();
        table.Columns.AddRange(new[]
            {
                new DataColumn("Name")
            });
        table.Rows.Add("david");
        table.Rows.Add("Ruud");
        // your code
        Stream s = RenderDataTableToExcel(dt);
        if (s != null)
        {
            MemoryStream ms = s as MemoryStream;
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + HttpUtility.UrlEncode(reportName) + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"));
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Length", ms.ToArray().Length.ToString());
            Response.BinaryWrite(ms.ToArray());
            Response.Flush();
            ms.Close();
            ms.Dispose();
        }
        else
            Response.Write("Error!Connot Download");
        }
    }
