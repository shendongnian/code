    public static void ExportToCSV(DataTable contentToexport)
    {
        StringBuilder csvData = new StringBuilder();
        StringBuilder headers = new StringBuilder();
    
        foreach (DataRow row in contentToexport.Rows)
        {
            headers = string.Empty;
            foreach (DataColumn column in contentToexport.Columns)
            {
                csvData.Append(row[column].ToString() + ",");
                headers.Append(column.ColumnName + ",");
            }
    
           csvData.Append("\r\n");
           headers.Append("\r\n");
        }
    
        string contentToExport = headers.Append(csvData.ToString()).ToString();
        string attachment = "attachment; filename=export.csv";
    
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/csv";
        HttpContext.Current.Response.AddHeader("Pragma", "public");
        HttpContext.Current.Response.Write(contentToExport);
        System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
   
