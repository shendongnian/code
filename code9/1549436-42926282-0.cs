    [System.Web.Services.WebMethod]
    public static string GetData()
    {
        DataTable dt = GetDataTable();
         
        return BuildJSONFromDT(dt);
    }
    
    private static string BuildJSONFromDT(DataTable dt)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
     
        List<object> resultMain = new List<object>();
     
        foreach (DataRow row in dt.Rows)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (DataColumn column in dt.Columns)
            {
                result.Add(column.ColumnName, "" + row[column.ColumnName]);
            }
     
            resultMain.Add(result);
        }
     
        return serializer.Serialize(resultMain);
    }
